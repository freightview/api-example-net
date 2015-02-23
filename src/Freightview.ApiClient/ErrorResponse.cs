using System.Collections.Generic;

namespace Freightview.ApiClient
{
	public class ErrorResponse
	{
		public string message { get; set; }
		public string name { get; set; }
		public dynamic errors { get; set; }
	}
}