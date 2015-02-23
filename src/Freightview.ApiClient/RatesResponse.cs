using System.Collections.Generic;

namespace Freightview.ApiClient
{
	public class RatesResponse : RatesRequest
	{
		public List<QuoteRate> rates { get; set; }
	}
}