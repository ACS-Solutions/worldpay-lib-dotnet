using System;
using System.Configuration;
using Microsoft.Extensions.Options;

namespace Worldpay.Sdk
{
	public class Config
	{
		/// <summary>
		/// Uri of the token request API
		/// </summary>
		public string TokenUrl { get; set; }

		/// <summary>
		/// Base Uri of the service
		/// </summary>
		public string BaseUrl { get; set; }

		/// <summary>
		/// The secret key for service authorization
		/// </summary>
		public string ServiceKey { get; set; }

		/// <summary>
		/// The merchant id corresponding to the service and client key
		/// </summary>
		public string MerchantId { get; set; }

		/// <summary>
		/// The client key for service authorization
		/// </summary>
		public string ClientKey { get; set; }

		public string OrderLog { get; set; }

		public string WebhookUrl { get; set; }
	}

	public static class Configuration
	{
		// The DI / No DI situation gets bridged by the Startup class stuffing this from config
		public static Config Current { get; set; }

		public static string TokenUrl
		{
			get
			{
				return Current.TokenUrl;
			}
		}
		public static string BaseUrl
		{
			get
			{
				return Current.BaseUrl;
			}
		}
		public static string ServiceKey
		{
			get
			{
				return Current.ServiceKey;
			}
		}
		public static string MerchantId
		{
			get
			{
				return Current.MerchantId;
			}
		}
		public static string ClientKey
		{
			get
			{
				return Current.ClientKey;
			}
		}
		public static string OrderLog
		{
			get
			{
				return Current.OrderLog;
			}
		}
		public static string WebhookUrl
		{
			get
			{
				return Current.WebhookUrl;
			}
		}
	}
}