using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Worldpay.Sdk.Enums;
using Worldpay.Sdk.Models;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Worldpay.Sdk
{
	/// <summary>
	/// Class for handling generic HTTP API interactions
	/// </summary>
	public class Http
	{
		/// <summary>
		/// Connection timeout in milliseconds
		/// </summary>
		private const int ConnectionTimeout = 61000;

		/// <summary>
		/// JSON header value
		/// </summary>
		private const string ApplicationJson = "application/json";

		/// <summary>
		/// Service key
		/// </summary>
		private readonly string _serviceKey;

		/// <summary>
		/// Authenticated
		/// </summary>
		private readonly bool _authenticated;

		/// <summary>
		/// Constructor
		/// </summary>
		public Http()
		{
			_authenticated = false;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="serviceKey">The authorization key for the service</param>
		public Http( string serviceKey )
		{
			_serviceKey = serviceKey;
			_authenticated = true;
		}

		/// <summary>
		/// Perform a GET request
		/// </summary>
		internal async Task<TO> Get<TO>( string api )
		{
			HttpWebRequest request = await CreateRequest( api, RequestMethod.Get, null, _authenticated );
			return await SendRequest<TO>( request );
		}

		/// <summary>
		/// Perform a POST request
		/// </summary>
		internal async Task Post( string api, object item )
		{
			HttpWebRequest request = await CreateRequest( api, RequestMethod.Post, item, _authenticated );
			await SendRequest( request );
		}

		/// <summary>
		/// Perform a PUT request
		/// </summary>
		internal async Task Put( string api, object item )
		{
			HttpWebRequest request = await CreateRequest( api, RequestMethod.Put, item, _authenticated );
			await SendRequest( request );
		}

		/// <summary>
		/// Perform a POST request
		/// </summary>
		internal async Task<TO> Post<TI, TO>( string api, TI item )
		{
			HttpWebRequest request = await CreateRequest( api, RequestMethod.Post, item, _authenticated );
			return await SendRequest<TO>( request );
		}

		/// <summary>
		/// Perform a POST request
		/// </summary>
		internal async Task<TO> Put<TI, TO>( string api, TI item )
		{
			HttpWebRequest request = await CreateRequest( api, RequestMethod.Put, item, _authenticated );
			return await SendRequest<TO>( request );
		}

		/// <summary>
		/// Perform a DELETE request
		/// </summary>
		public async Task Delete( string api )
		{
			HttpWebRequest request = await CreateRequest( api, RequestMethod.Delete, null, _authenticated );
			await SendRequest( request );
		}

		/// <summary>
		/// Handle an incoming request
		/// </summary>
		/// <typeparam name="TO"></typeparam>
		/// <param name="request"></param>
		/// <returns></returns>
		public TO HandleRequest<TO>( HttpRequest request )
		{
			if( request.HttpMethod != "POST" )
			{
				throw new WorldpayException( "Invalid request" );
			}

			return HandleResponse<TO>( request.InputStream );
		}

		#region helpers

		private async Task<HttpWebRequest> CreateRequest( string api, RequestMethod method, object data, bool authorize )
		{
			var request = (HttpWebRequest)HttpWebRequest.Create( api );
			request.Accept = ApplicationJson;
			request.Timeout = ConnectionTimeout;

			switch( method )
			{
				case RequestMethod.Get:
					request.Method = WebRequestMethods.Http.Get;
					break;
				case RequestMethod.Post:
					request.Method = WebRequestMethods.Http.Post;
					break;
				case RequestMethod.Put:
					request.Method = WebRequestMethods.Http.Put;
					break;
				case RequestMethod.Delete:
					request.Method = "DELETE";
					break;
				default:
					throw new NotSupportedException( String.Format( "Request method {0} not supported", method.ToString() ) );
			}

			if( authorize )
			{
				request.Headers.Add( HttpRequestHeader.Authorization, _serviceKey );
			}

			try
			{
				if( data != null )
				{
					request.ContentType = ApplicationJson;

					using( var outputStream = await request.GetRequestStreamAsync() )
					using( var textWriter = new StreamWriter( outputStream ) )
					using( var jsonWriter = new JsonTextWriter( textWriter ) )
					{
						GetJsonSerializer().Serialize( jsonWriter, data );
					}
				}
			}
			catch( WebException exc )
			{
				throw new WebException( "Error with request " + request.RequestUri, exc );
			}

			return request;
		}

		private async Task SendRequest( HttpWebRequest request )
		{
			try
			{
				using( var response = await request.GetResponseAsync() )
				{
					// NO action to take
				}
			}
			catch( WebException exc )
			{
				HandleError( exc );
			}
		}

		private async Task<T> SendRequest<T>( HttpWebRequest request )
		{
			try
			{
				using( var response = await request.GetResponseAsync() )
				{
					return HandleResponse<T>( response.GetResponseStream() );
				}
			}
			catch( WebException exc )
			{
				HandleError( exc );
				return default( T );
			}
		}

		private static JsonSerializer GetJsonSerializer()
		{
			// Should use DI

			var serializer = new JsonSerializer();
#if DEBUG
			serializer.TraceWriter = new DiagnosticsTraceWriter() { LevelFilter = System.Diagnostics.TraceLevel.Verbose };
#endif
			serializer.MissingMemberHandling = MissingMemberHandling.Ignore;
			serializer.Converters.Add(
				new StringEnumConverter()
			);

			return serializer;
		}

		private T HandleResponse<T>( Stream responseStream )
		{
			using( var reader = new StreamReader( responseStream ) )
			{
				return GetJsonSerializer().Deserialize<T>( new JsonTextReader( reader ) );
			}
		}

		private void HandleError( WebException exc )
		{
			using( var reader = new StreamReader( exc.Response.GetResponseStream() ) )
			using( var jsonReader = new JsonTextReader( reader ) )
			{
				ApiError error = null;
				try
				{
					error = GetJsonSerializer().Deserialize<ApiError>( jsonReader );
				}
				catch( Exception )
				{
					throw exc;
				}
				throw new WorldpayException( error, "API error: " + error.message );
			}
		}

		#endregion

	}
}
