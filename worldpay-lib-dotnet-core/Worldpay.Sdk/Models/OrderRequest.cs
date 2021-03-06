﻿using System;
using System.Collections.Generic;

namespace Worldpay.Sdk
{
	using Enums;

	namespace Models
	{

		[Serializable]
		public class OrderRequest : AbstractOrder
		{
			public OrderRequest()
			{
				this.threeDSecureInfo = new ThreeDSecureInfo();
			}

			public string name { get; set; }

			public Address billingAddress { get; set; }

			public DeliveryAddress deliveryAddress { get; set; }

			public Dictionary<string, string> customerIdentifiers { get; set; }

			public string customerOrderCode { get; set; }

			public string orderCodeSuffix { get; set; }

			public string orderCodePrefix { get; set; }

			public ISO639_1 shopperLanguageCode { get; set; }

			public bool reusable { get; set; }

			public AbstractPaymentMethod paymentMethod { get; set; }

			public ThreeDSecureInfo threeDSecureInfo { get; set; }

			public string shopperIpAddress
			{
				get { return threeDSecureInfo.shopperIpAddress; }
				set { threeDSecureInfo.shopperIpAddress = value; }
			}

			public string shopperSessionId
			{
				get { return threeDSecureInfo.shopperSessionId; }
				set { threeDSecureInfo.shopperSessionId = value; }
			}

			public string shopperUserAgent
			{
				get { return threeDSecureInfo.shopperUserAgent; }
				set { threeDSecureInfo.shopperUserAgent = value; }
			}

			public string shopperAcceptHeader
			{
				get { return threeDSecureInfo.shopperAcceptHeader; }
				set { threeDSecureInfo.shopperAcceptHeader = value; }
			}

			public bool is3DSOrder { get; set; }

			public string successUrl { get; set; }

			public string failureUrl { get; set; }

			public string cancelUrl { get; set; }

			public string pendingUrl { get; set; }

			public string shopperEmailAddress { get; set; }

			public string statementNarrative { get; set; }

		}
	}
}