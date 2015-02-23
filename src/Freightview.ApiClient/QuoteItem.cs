namespace Freightview.ApiClient
{
	public class QuoteItem
	{
		public int weight { get; set; }
		public decimal freightClass { get; set; }
		public int length { get; set; }
		public int width { get; set; }
		public int height { get; set; }
		public string package { get; set; }
		public int pieces { get; set; }
		public bool hazardous { get; set; }
		public string nmfc { get; set; }
	}
}