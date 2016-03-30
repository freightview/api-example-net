using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Freightview.ApiClient
{
	public class ApiClient
	{
		public List<MediaTypeFormatter> formatters { get; private set; }
		public ApiClient(HttpClient apiClient)
		{
			this.Client = apiClient;
			this.formatters = new List<MediaTypeFormatter>();
			this.formatters.Add(new JsonMediaTypeFormatter() {SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore}});
			this.formatters.Add(new XmlMediaTypeFormatter());
		}

		protected HttpClient Client { get; set; }

		protected async Task CheckErrors(HttpResponseMessage response)
		{
			if (!response.IsSuccessStatusCode)
				await HandleError(response);
		}

		protected async Task<Stream> HandleStreamResponse(HttpResponseMessage response)
		{
			await CheckErrors(response);
			return await response.Content.ReadAsStreamAsync();
		}
		protected async Task<string> HandleResponseString(HttpResponseMessage response)
		{
			await CheckErrors(response);
			return await response.Content.ReadAsStringAsync();
		}
		protected async Task<T> HandleResponse<T>(HttpResponseMessage response)
		{
			await CheckErrors(response);
			return await response.Content.ReadAsAsync<T>(formatters);
		}
		protected async Task HandleResponse(HttpResponseMessage response)
		{
			await CheckErrors(response);
		}
		protected async Task HandleError(HttpResponseMessage response)
		{
			Exception err = null;
			try
			{
				var error = await response.Content.ReadAsAsync<ErrorResponse>(formatters);
				err = new ApiException(error);
			}
			catch {} //failed parsing content as ErrorResponse; ignore and just read all the content 

			if (err == null)
			{
				var content = await response.Content.ReadAsStringAsync();
				err = new ApplicationException(string.Format("API response status code: {0} {1}; {2}", (int)response.StatusCode, response.StatusCode, content));
			}

			throw err;
		}
		public async Task<RatesResponse> GetRates(RatesRequest ratesRequest)
		{
			var response = await Client.PostAsJsonAsync("rates", ratesRequest);
			return await HandleResponse<RatesResponse>(response);
		}
	}
}
