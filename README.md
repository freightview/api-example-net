#.NET API Client
This is just a basic example showing how to get rates using C#. 

##Get Started
To test this client, first update the `Program.cs` file with your API credentials. Find the `credentials` variable on line 35. Replace its contents with your API Key followed by a `:`. Our API uses the API key as the HTTP basic auth header username with no password; hence, the `:`. 

Compile and Run (with F5) the app and you should see your rate results for this example quote. 

Refer to the [API Documentation](http://developer.freightview.com/v1.0/docs/rates) for details about what options you can use in fields like `paymentTerms`, `destType`,`originType`, and `charges`.  
