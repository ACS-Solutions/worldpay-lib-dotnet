namespace Worldpay.Sdk.Enums
{
	public enum OrderType
	{
		ECOM, // the default value for an order
		RECURRING, // set the order to be of type recurring
		MOTO, // set the order to be of type Mail Order Telephone Order / Virtual Terminal
		APM // Alternative Payment Method, e.g. PayPal
	}
}
