using System;

namespace Worldpay.Sdk
{
	using Enums;

	namespace Models
	{
		[Serializable]

		public class TransferDetail
		{
			public Settlement[] paymentsSettled { get; set; }
			public Settlement[] paymentChargeBacks { get; set; }
			public Settlement[] paymentReverseChargeBacks { get; set; }
			public Settlement[] paymentRefunds { get; set; }
		}
	}
}