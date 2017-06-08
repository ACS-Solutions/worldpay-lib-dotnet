using System;

namespace Worldpay.Sdk
{
	namespace Models
	{
		[Serializable]
		public class TransfersResponse
		{
			public Int32 currentPageNumber { get; set; }
			public Int32 totalPages { get; set; }
			public Int32 numberOfElements { get; set; }
			public TransferSummary[] transfers { get; set; }
		}
	}
}