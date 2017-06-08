using System;

namespace Worldpay.Sdk
{
	using Enums;
	namespace Models
	{
		[Serializable]
		public class MiscellaneousDetail
		{
			public String description { get; set; }
			public Int32 netAmount { get; set; }
			public CurrencyCode settlementCurrency { get; set; }
			public Int32 settlementCurrencyExponent { get; set; }
		}
	}
}