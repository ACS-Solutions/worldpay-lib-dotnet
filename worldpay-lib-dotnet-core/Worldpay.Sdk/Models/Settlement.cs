using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Worldpay.Sdk
{

	using Enums;

	namespace Models
	{
		public class Settlement
		{
			public DateTime modificationDate { get; set; }
			public Guid orderCode { get; set; }
			public String customerOrderCode { get; set; }
			public CardType cardType { get; set; }
			public CurrencyCode currencyCode { get; set; }
			public Int32 currencyCodeExponent { get; set; }
			public Int32 amount { get; set; }
			public String exchangeRate { get; set; }
			public Int32 commission { get; set; }
			public Int32 netAmount { get; set; }
		}
	}
}