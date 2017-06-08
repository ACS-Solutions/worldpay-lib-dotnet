﻿using System;
using WorldPay.Sdk.Models;
using Worldpay.Sdk.Models;
using System.Threading.Tasks;

namespace Worldpay.Sdk
{
	/// <summary>
	/// Service for interacting with the Worldpay Order API
	/// </summary>
	[Serializable]
	public class OrderService : AbstractService
	{
		private readonly string _baseUrl;

		/// <summary>
		/// Constructor
		/// </summary>
		public OrderService( string baseUrl, Http http )
			: base( http )
		{
			_baseUrl = baseUrl;
		}

		/// <summary>
		/// Retrieve an existing order
		/// </summary>
		/// <param name="orderCode">Code of the order to retrieve</param>
		/// <returns>Details of the existing order</returns>
		public async Task<OrderResponse> FindOrder( string orderCode )
		{
			return await Http.Get<OrderResponse>( String.Format( "{0}/orders/{1}", _baseUrl, orderCode ) );
		}

		/// <summary>
		/// Create a new order
		/// </summary>
		/// <param name="orderRequest">Details of the order to be created</param>
		/// <returns>Confirmation of the new order</returns>
		public async Task<OrderResponse> Create( OrderRequest orderRequest )
		{
			return await Http.Post<OrderRequest, OrderResponse>( _baseUrl + "/orders", orderRequest );
		}

		/// <summary>
		/// Capture entire payment from an authorized order.
		/// </summary>
		/// <param name="orderCode">The code of the authorized order to capture.</param>
		/// <returns>Confirmation of the captured order</returns>
		public async Task<OrderResponse> CaptureAuthorizedOrder( string orderCode )
		{
			return await Http.Post<CaptureRequest, OrderResponse>( String.Format( "{0}/orders/{1}/capture", _baseUrl, orderCode ), null );
		}

		/// <summary>
		/// Partially capture payment from an authorized order.
		/// </summary>
		/// <param name="orderCode">The code of the authorized order to capture.</param>
		/// <param name="amount">The amount to capture. This must be less than or equal to the amount that was Authorized.</param>
		/// <returns>Confirmation of the captured order</returns>
		public async Task<OrderResponse> CaptureAuthorizedOrder( string orderCode, int amount )
		{
			if( amount == 0 )
			{
				return await CaptureAuthorizedOrder( orderCode );
			}
			else
			{
				return await Http.Post<CaptureRequest, OrderResponse>( String.Format( "{0}/orders/{1}/capture", _baseUrl, orderCode ), new CaptureRequest { captureAmount = amount } );
			}
		}

		/// <summary>
		/// Cancel an authorized order.
		/// </summary>
		/// <param name="orderCode">The code of the authorized order to cancel.</param>
		public async Task CancelAuthorizedOrder( string orderCode )
		{
			await Http.Delete( String.Format( "{0}/orders/{1}", _baseUrl, orderCode ) );
		}

		/// <summary>
		/// Authorize a 3DS order
		/// </summary>
		/// <param name="orderCode">Order code for the orer to be authorized</param>
		/// <param name="responseCode">Authorization Response code from Issuer</param>
		/// <param name="threeDSInfo">3D Secure Information</param>
		/// <returns>Confirmation of the new order</returns>
		public async Task<OrderResponse> Authorize( string orderCode, string responseCode, ThreeDSecureInfo threeDSInfo )
		{
			return await Http.Put<OrderAuthorizationRequest, OrderResponse>(
				String.Format( "{0}/orders/{1}", _baseUrl, orderCode ),
				new OrderAuthorizationRequest()
				{
					threeDSResponseCode = responseCode,
					threeDSecureInfo = threeDSInfo
				}
			);
		}

		/// <summary>
		/// Refund and existing order
		/// </summary>
		/// <param name="orderCode">The code of the order to be refunded</param>
		public async Task Refund( String orderCode )
		{
			await Http.Post( String.Format( "{0}/orders/{1}/refund", _baseUrl, orderCode ), null );
		}

		/// <summary>
		/// Partially refund an existing order
		/// </summary>
		/// <param name="orderCode">The code of the order to be partially refunded</param>
		/// <param name="amount">The amount of the order to be partially refunded</param>
		public async Task Refund( String orderCode, int amount )
		{
			if( amount == 0 )
			{
				await Refund( orderCode );
			}
			else
			{
				PartialRefundRequest partialRefundRequest = new PartialRefundRequest { refundAmount = amount };
				await Http.Post( String.Format( "{0}/orders/{1}/refund", _baseUrl, orderCode ), partialRefundRequest );
			}
		}
	}
}
