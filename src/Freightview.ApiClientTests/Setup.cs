using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Freightview.ApiClientTests
{
	public static class Setup
	{
		public static ApiClient.ApiClient GetClient()
		{
			var utf8 = new System.Text.UTF8Encoding(false, false);

			var http = new HttpClient();
			http.BaseAddress = new Uri("http://10.211.55.2:3001/api/v1/");
			http.BaseAddress = new Uri("https://www.freightview.com/api/v1/");

			//Auth header is username:password. For ours use: "api-key:"
			var credentials = "14b50208901be261144a8b217e84821b7da835128cb:"; //pull this from a secure config
			if (!string.IsNullOrWhiteSpace(credentials))
				http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(utf8.GetBytes(credentials)));

			return new ApiClient.ApiClient(http);
		}
	}
}
