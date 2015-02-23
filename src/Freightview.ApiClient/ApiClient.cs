using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Freightview.ApiClient
{
	public class ApiClient
	{
		public ApiClient(HttpClient apiClient)
		{
			this.Client = apiClient;
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
			return await response.Content.ReadAsAsync<T>();
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
				var error = await response.Content.ReadAsAsync<ErrorResponse>();
				err = new ApiException(error);
			}
			catch {} //failed parsing content as ErrorResponse; ignore and just read all the content 

			if (err == null)
			{
				var content = await response.Content.ReadAsStringAsync();
				err = new ApplicationException(content);
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
