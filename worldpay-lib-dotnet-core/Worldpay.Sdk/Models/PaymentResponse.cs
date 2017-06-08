using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using Worldpay.Sdk.Enums;

namespace Worldpay.Sdk.Models
{
	[Serializable]
	public class PaymentResponse : AbstractCard
	{
		public CardType cardType { get; set; }

		public string maskedCardNumber { get; set; }

		public Address billingAddress { get; set; }

		public CardSchemeType cardSchemeType { get; set; }

		public string cardSchemeName { get; set; }

		public string cardIssuer { get; set; }

		public CountryCode countryCode { get; set; }

		public CardClass cardClass { get; set; }

		public string cardProductTypeDescNonContactless { get; set; }

		public string cardProductTypeDescContactless { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public string prepaid { get; set; } // true, false, unknown

		[XmlIgnore]
		[JsonIgnore]
		// [NonSerialized]
		public bool? isPrepaid {
			get
			{
				bool? result = null;
				bool temp;
				if( bool.TryParse( prepaid, out temp ) )
				{
					result = temp;
				}
				return result;
			}
			set
			{
				prepaid = value.HasValue ? value.Value.ToString().ToLowerInvariant() : "unknown";
			}
		}

		public Dictionary<string, string> apmFields { get; set; }

	}
}
