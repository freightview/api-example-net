using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Freightview.ApiClient
{
	class Program
	{
		static void Main(string[] args)
		{
			//since we're not running this under an async method, we can manually invoke the awaitable task. 
			//as a web application in MVC 4+, you can use Tasks for your controller actions that are async. 

			//this is the manual way. ;) 
			var task = TestRates();
			task.Wait(30000); //30 sec timeout. 
		}

		static async Task TestRates()
		{

			//basic boiler plate to setup an HTTP client with authorization headers included automatically
			var utf8 = new System.Text.UTF8Encoding(false, false);
			var http = new HttpClient();
			http.BaseAddress = new Uri("http://10.211.55.2:3001/api/v1/"); //our local dev
//			http.BaseAddress = new Uri("https://www.freightview.com/api/v1/");

			//Auth header is username:password. For ours use: "api-key:"
			var credentials = "14b50208901be261144a8b217e84821b7da835128cb:"; //pull this from a secure config
			if (!string.IsNullOrWhiteSpace(credentials))
				//set the default AUTH header on all calls using this HTTPClient
				http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(utf8.GetBytes(credentials)));

			//APIClient encapsulates an HttpClient to simplify parsing,serializing JSON to common endpoints. (You could even use dependency injection if you wanted to). 
			var apiClient = new ApiClient(http);

			//basic rates request using sample on the API docs. 
			var request = new RatesRequest()
			{
				pickupDate = new DateTime(2014, 12, 1) //FYI - time is UTC-0
				,originPostalCode = "30303"
				,originType = "business dock"
				,destPostalCode = "60606"
				,destType = "business dock"
				,paymentTerms = "Outbound Prepaid"
				,items = new List<QuoteItem>()
						{
							new QuoteItem()
								{
									freightClass = 50
									,weight = 500
									,length = 48
									,width	= 48
									,height = 48
									,hazardous = false
									,pieces = 1
									,package = "Pallets_other"
								}
						}
				,charges = new List<string>()
						{
							"liftgate pickup"
						}
			};

			try
			{
				//Go get the results
				var result = await apiClient.GetRates(request);

				Console.WriteLine(string.Format("Returned with {0} rates.", result.rates.Count));
				foreach (var rate in result.rates)
					Console.WriteLine(rate.ToString());
			}
			catch (Exception ex)
			{
				//We've created a basic ErrorResponse type that can parse some of our errors.  The `errors` field itself is
				//	dynamic which fluctuates depending on the type of error. 
				Console.WriteLine(ex.ToString());
			}
		}
	}
}
