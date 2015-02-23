using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Freightview.ApiClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Freightview.ApiClientTests
{
	[TestClass]
	public class When_getting_rates_with_outbound_prepaid
	{
		private RatesRequest request;
		private string credentials;
		private ApiClient.ApiClient apiClient;
		private RatesResponse result;

		[TestInitialize]
		public void Init()
		{
			this.apiClient = Setup.GetClient();
			this.request = new RatesRequest()
			{
				pickupDate = new DateTime(2014, 12, 1)
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

			var task = apiClient.GetRates(request);
			task.Wait(30000);
			this.result = task.Result;
		}

		[TestMethod]
		public void Should_contain_rates()
		{
			Assert.IsNotNull(result.rates);
		}
	}
}
