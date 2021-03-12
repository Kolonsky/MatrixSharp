using System;
using System.Net;
using System.Runtime.Serialization;
using MatrixSharp.Entities;

namespace MatrixSharp.Exceptions
{
	[Serializable]
	public class ApiException : Exception
	{
		public ApiException(string message, StandardErrorResponse errorResponse, HttpStatusCode httpStatusCode) :
			base(message)
		{
			ErrorResponse = errorResponse;
			HttpStatusCode = httpStatusCode;
		}

		public ApiException(string message, StandardErrorResponse errorResponse, HttpStatusCode httpStatusCode,
			Exception inner) : base(
			message, inner)
		{
			ErrorResponse = errorResponse;
			HttpStatusCode = httpStatusCode;
		}

		protected ApiException(
			SerializationInfo info,
			StreamingContext context) : base(info, context)
		{
			ErrorResponse = (StandardErrorResponse) info.GetValue(nameof(ErrorResponse), typeof(StandardErrorResponse));
			HttpStatusCode = (HttpStatusCode) info.GetValue(nameof(HttpStatusCode), typeof(HttpStatusCode));
		}

		public HttpStatusCode HttpStatusCode { get; init; }
		public StandardErrorResponse ErrorResponse { get; set; }

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);

			info.AddValue(nameof(ErrorResponse), ErrorResponse, typeof(StandardErrorResponse));
			info.AddValue(nameof(HttpStatusCode), HttpStatusCode, typeof(HttpStatusCode));
		}
	}
}