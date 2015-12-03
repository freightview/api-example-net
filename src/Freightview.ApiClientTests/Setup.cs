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
            //VMWare Fusion: "http://172.16.174.1:3001/api/v1/"
            //Parallels: "http://10.211.55.2:3001/api/v1/"
            http.BaseAddress = new Uri("https://www.freightview.com/api/v1");

            //Repace this header with your own API key. 
			//Auth header is username:password. For ours use: "api-key:"
            var credentials = "1506208f5dfc2147cd0bde58e9e05fb81539e0f5c13:"; //pull this from a secure config
			if (!string.IsNullOrWhiteSpace(credentials))
				http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(utf8.GetBytes(credentials)));

			return new ApiClient.ApiClient(http);
		}
	}
}
