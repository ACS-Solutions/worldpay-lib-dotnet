using System.Runtime.Serialization;

namespace Worldpay.Sdk.Enums
{
	public enum AvsResultCode
	{
		APPROVED, // The supplied street and postal code details fully matched the payment provider's records

		[EnumMember( Value = "PARTIAL APPROVED" )]
		PARTIAL_APPROVED, // One of the supplied street or postal code details did not match the payment provider's records

		[EnumMember( Value = "NOT SENT TO ACQUIRER" )]
		NOT_SENT_TO_ACQUIRER, // Problem with acquirer - possibly no AVS support

		[EnumMember( Value = "NO RESPONSE FROM ACQUIRER" )]
		NO_RESPONSE_FROM_ACQUIRER, // Problem with acquirer - possibly no AVS support

		[EnumMember( Value = "NOT CHECKED BY ACQUIRER" )]
		NOT_CHECKED_BY_ACQUIRER, // The acquirer did not check the address details

		[EnumMember( Value = "NOT SUPPLIED BY SHOPPER" )]
		NOT_SUPPLIED_BY_SHOPPER, // Missing, incomplete or invalid address details in the order prevented the address from being checked

		FAILED // Both street and postal code details did not match the payment provider's records
	}
}
