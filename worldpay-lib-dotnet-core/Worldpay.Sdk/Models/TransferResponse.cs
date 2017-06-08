using System;

namespace Worldpay.Sdk
{
	using Enums;

	namespace Models
	{
		[Serializable]
		public class TransferResponse
		{
			public Guid transferId { get; set; }

			[Obsolete]
			public TransferOrder[] orders { get; set; }

			public Int32 batchId { get; set; }

			public String merchantCode { get; set; }

			public DateTime reportDate { get; set; }

			public CurrencyCode settlementCurrency { get; set; }

			public DateTime transferDate { get; set; }

			public TransferDetail transferDetails { get; set; }

			public MiscellaneousDetail[] miscellaneousDetails { get; set; }

			public MiscellaneousDetail depositCorrectionDetail { get; set; }

			public Int32 transferNetAmount { get; set; }

			public CurrencyCode transferAmountCurrencyCode { get; set; }

			public Int32 transferAmountCurrencyCodeExponent { get; set; }
		}
	}
}