﻿using System;
using System.Threading.Tasks;
using Worldpay.Sdk.Models;

namespace Worldpay.Sdk
{
    /// <summary>
    /// Service for interacting with the Worldpay Order API
    /// </summary>
    [Serializable]
    public class SettingsService : AbstractService
    {
        private readonly string _baseUrl;

        /// <summary>
        /// Constructor
        /// </summary>
        public SettingsService(string baseUrl, Http http) : base(http)
        {
            _baseUrl = baseUrl;
        }

		/// <summary>
		///
		/// </summary>
		/// <param name="merchantId"></param>
		/// <returns></returns>
		public async Task<SettingsResponse> GetSettings( string merchantId )
		{
			var url = String.Format( "{0}/merchants/{1}/settings", _baseUrl, merchantId );
			return await Http.Get<SettingsResponse>( url );
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="merchantId"></param>
		/// <param name="riskSettings"></param>
		public async Task UpdateRiskSettings(string merchantId, RiskSetting riskSettings)
        {
            var url = String.Format("{0}/merchants/{1}/settings/riskSettings", _baseUrl, merchantId);
            await Http.Put<RiskSetting, RiskSetting>(url, riskSettings);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="enable"></param>
        public async Task UpdateRecurringBilling(string merchantId, bool enable)
        {
            var url = String.Format("{0}/merchants/{1}/settings/orderSettings/recurringBilling/{2}", _baseUrl, merchantId, enable);
            await Http.Put<RiskSetting, RiskSetting>(url, null);
        }
    }
}
