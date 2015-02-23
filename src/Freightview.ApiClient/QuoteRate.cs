namespace Freightview.ApiClient
{
	public class QuoteRate
	{
		public string status { get; set; }
		public string paymentTerms { get; set; }
		public decimal total { get; set; }
		public string @ref { get; set; }
		public int days { get; set; }
		public string serviceLevel { get; set; }
		public string carrier { get; set; }
		public string code { get; set; }
		public string provider { get; set; }
		public string providerCode { get; set; }

		public override string ToString()
		{
			return string.Format("{0} - {1}{2} {3} {4} {5} days {6}", status, carrier,
			                     !string.IsNullOrWhiteSpace(provider) ? "/" + provider : string.Empty,
			                     total.ToString("N2"), @ref, days, serviceLevel);
		}
	}
}