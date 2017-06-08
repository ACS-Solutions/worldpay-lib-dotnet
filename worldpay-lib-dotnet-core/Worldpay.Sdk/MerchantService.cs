using System;
using System.Threading.Tasks;
using Worldpay.Sdk.Models;

namespace Worldpay.Sdk
{
    public class MerchantService : AbstractService
    {
        private readonly string _baseUrl;

        /// <summary>
        /// Constructor
        /// </summary>
        public MerchantService(string baseUrl, Http http) : base(http)
        {
            _baseUrl = baseUrl;
        }

		/// <summary>
		///
		/// </summary>
		/// <param name="merchant"></param>
		public async Task Create( BaseMerchant merchant )
		{
			await Http.Post( String.Format( "{0}/merchants", _baseUrl ), merchant );
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="merchantId"></param>
		public async Task<Merchant> Get( string merchantId )
		{
			return await Http.Get<Merchant>( String.Format( "{0}/merchants/{1}", _baseUrl, merchantId ) );
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="merchantId"></param>
		/// <param name="merchant"></param>
		public async Task Update( string merchantId, Merchant merchant )
		{
			await Http.Post( String.Format( "{0}/merchants/{1}", _baseUrl, merchantId ), merchant );
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="merchantId"></param>
		/// <param name="merchant"></param>
		public async Task Put(string merchantId, Merchant merchant)
        {
            await Http.Post(String.Format("{0}/merchants/{1}", _baseUrl, merchantId), merchant);
        }

    }
}
