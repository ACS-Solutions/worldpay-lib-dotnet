namespace Worldpay.Sdk
{
	using Enums;

	namespace Models
	{
		public class AbstractOrder
		{
			public string token { get; set; }

			public OrderType orderType { get; set; }

			public string orderDescription { get; set; }

			public int? amount { get; set; }

			public CurrencyCode currencyCode { get; set; }

			public CurrencyCode settlementCurrency { get; set; }

			public string siteCode { get; set; }

			public bool authorizeOnly { get; set; }

			public int? authorizedAmount { get; set; }

		}
	}
}