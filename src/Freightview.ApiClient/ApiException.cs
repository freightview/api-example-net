using System;

namespace Freightview.ApiClient
{
	public class ApiException : ApplicationException
	{
		public string message { get; set; }
		public string name { get; set; }
		public dynamic errors { get; set; }

		public ApiException(ErrorResponse error)
			: base(error.message)
		{
			this.message = error.message;
			this.name = error.name;
			this.errors = error.errors;
		}

		public override string ToString()
		{
			return string.Format("{0}\nMessage:\n{1}\nStack Trace:\n{2}", this.name, this.message, this.StackTrace);
		}
	}
}