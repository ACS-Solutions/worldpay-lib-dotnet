using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Worldpay.Sdk
{
	using Enums;

	namespace Models
	{

		public class ResultCodes
		{
			public AvsResultCode avsResultCode { get; set; }
			public CvcResultCode cvcResultCode { get; set; }

		}
	}
}