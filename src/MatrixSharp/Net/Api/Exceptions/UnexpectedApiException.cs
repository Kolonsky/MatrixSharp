using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSharp.Net.Api.Exceptions
{
	/// <summary>
	/// Represents an exception thrown when the response from the server was valid but did not meet the Matrix specification.
	/// </summary>
	[Serializable]
	public class UnexpectedApiException : Exception
	{
		public HttpResponseMessage Response { get; set; }

		public UnexpectedApiException(string message, HttpResponseMessage response) : base(message)
		{
			Response = response;
		}

		public UnexpectedApiException(string message, HttpResponseMessage response, Exception inner) : base(message, inner)
		{
			Response = response;
		}

		protected UnexpectedApiException(
			SerializationInfo info,
			StreamingContext context) : base(info, context)
		{
			Response = (HttpResponseMessage) info.GetValue(nameof(Response), typeof(HttpResponseMessage));
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
			
			info.AddValue(nameof(Response), Response, typeof(HttpResponseMessage));
		}
	}
}
