using System;

namespace Worldpay.Sdk
{
	using Enums;

	namespace Models
	{
		[Serializable]
		public class TransferSummary
		{
			public Int32 netAmount { get; set; }

			public CurrencyCode settlementCurrency { get; set; }

			public Int32 settlementCurrencyExponent { get; set; }

			public String bankName { get; set; }

			public String accountNumber { get; set; }

			public DateTime transferDate { get; set; }

			public Guid transferId { get; set; }

			public Int32 batchId { get; set; }

			public String merchantCode { get; set; }
		}
	}
}