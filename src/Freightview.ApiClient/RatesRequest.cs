using System;
using System.Collections.Generic;

namespace Freightview.ApiClient
{
	public class RatesRequest
	{
		public DateTime pickupDate { get; set; }
		
		public string originPostalCode { get; set; }
		public string originCountry { get; set; }
		public string originType { get; set; }
	
		public string destPostalCode { get; set; }
		public string destCountry { get; set; }
		public string destType { get; set; }

		public string billPostalCode { get; set; }
		public string billCountry { get; set; }

		public string paymentTerms { get; set; }
		public List<string> charges { get; set; }
		public List<QuoteItem> items { get; set; }
	}
}