using System;
using System.Threading.Tasks;
using Worldpay.Sdk.Models;

namespace Worldpay.Sdk
{
	/// <summary>
	///
	/// </summary>
	public class TransferService : AbstractService
	{
		/// <summary>
		///
		/// </summary>
		private readonly string _baseUrl;

		/// <summary>
		/// Constructor
		/// </summary>
		public TransferService( string baseUrl, Http http )
			: base( http )
		{
			_baseUrl = baseUrl;
		}

		/// <summary>
		///
		/// </summary>
		/// <returns></returns>
		public async Task<TransfersResponse> GetTransfers( Guid merchantId, int? pageNumber )
		{
			var url = String.Format( "{0}/transfers?merchantId={1}&pageNumber={2}", _baseUrl, merchantId, pageNumber );
			return await Http.Get<TransfersResponse>( url );
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="transferId"></param>
		public async Task<TransferResponse> GetTransfer( Guid transferId )
		{
			var url = String.Format( "{0}/transfers/{1}", _baseUrl, transferId );
			return await Http.Get<TransferResponse>( url );
		}
	}
}
