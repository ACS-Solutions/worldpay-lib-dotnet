using System.Runtime.Serialization;

namespace Worldpay.Sdk.Enums
{
    public enum CvcResultCode
    {
		APPROVED, // The supplied CVC details matched the payment provider's records

		[EnumMember( Value = "NOT SENT TO ACQUIRER" )]
		NOT_SENT_TO_ACQUIRER, // Problem with acquirer - possibly no CVC support

		[EnumMember( Value = "NO RESPONSE FROM ACQUIRER" )]
		NO_RESPONSE_FROM_ACQUIRER, // Problem with acquirer - possibly no CVC support

		[EnumMember( Value = "NOT CHECKED BY ACQUIRER" )]
		NOT_CHECKED_BY_ACQUIRER, // The acquirer did not check the CVC details

		[EnumMember( Value = "NOT SUPPLIED BY SHOPPER" )]
		NOT_SUPPLIED_BY_SHOPPER, // Missing, or invalid CVC in the payment details prevented the CVC from being checked

		FAILED, // The supplied CVC did not match the payment provider's records
    }
}
