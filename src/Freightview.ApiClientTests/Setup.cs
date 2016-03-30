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

			//Local dev testing:
			//VMWare Fusion:
//			http.BaseAddress = new Uri("http://192.168.12.1:3001/api/v1.0/");
			//Parallels: 
//			http.BaseAddress = new Uri("http://10.211.55.2:3001/api/v1.0/");
			//Production
			http.BaseAddress = new Uri("https://www.freightview.com/api/v1.0");

			//TODO: Repace this header with your own API key. 
			//Auth header is username:password. For ours use: "api-key:"
			var credentials = "1508ade3c6e255be5d75e5d37c7fc94525a2abd5cf7:";
			if (!string.IsNullOrWhiteSpace(credentials))
				http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(utf8.GetBytes(credentials)));

			return new ApiClient.ApiClient(http);
		}
	}
}
