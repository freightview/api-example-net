#.NET 4.5 API Client
This is just a basic example showing how to get rates using C# **4.5**.  4.5 is required due to the extension methods we're using to parse and map the JSON request and response easily. 

##Get Started
To test this client, first update the `Program.cs` file with your API credentials. Find the `credentials` variable on line 35. Replace its contents with your API Key followed by a `:`. Our API uses the API key as the HTTP basic auth header username with no password; hence, the `:`. 

Compile and Run (with F5) the app and you should see your rate results for this example quote. 

Refer to the [API Documentation](https://developer.freightview.com/#tag/Rating) for details about what options you can use in fields like `paymentTerms`, `destType`,`originType`, and `charges`.  
