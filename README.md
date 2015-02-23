#.NET API Client
This is just a basic example showing how to get rates using C#. 

##Get Started
First, download and update the `Program.cs` file with your API credentials. To do this, find the statement beneath `//TODO:` comment on line 35. Replace the content of the `credentials` variable with your API Key. **Don't forget to leave the `:` at the end of the string**

Our API uses the API key as the HTTP basic auth header username with no password.

Compile and Run (with F5) the app and you should see your rate results for this example quote. 

Refer to the [API Documentation](http://developer.freightview.com/v1.0/docs/rates) for details about what options you can use in fields like `paymentTerms`, `destType`,`originType`, and `charges`.  
