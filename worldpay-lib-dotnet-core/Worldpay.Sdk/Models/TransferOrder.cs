using System;
using System.Collections.Generic;
using Worldpay.Sdk.Enums;

namespace Worldpay.Sdk.Models
{
	[Serializable]
	[Obsolete]
	public class TransferOrder : OrderResponse
	{
		public OrderType orderType { get; set; }

		public int netAmount { get; set; }

		public int commission { get; set; }

		public int settlementCurrencyExponent { get; set; }

		public int chargedbackAmount { get; set; }

		public int currencyCodeExponent { get; set; }

		public DateTime creationDate { get; set; }

		public DateTime modificationDate { get; set; }

		public List<Warning> warnings { get; set; }
	}
}
