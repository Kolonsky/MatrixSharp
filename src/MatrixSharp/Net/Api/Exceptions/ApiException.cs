using System;
using System.Net;
using System.Runtime.Serialization;

namespace MatrixSharp.Net.Api.Exceptions
{
	[Serializable]
	public class ApiException : Exception
	{
		public ApiException(string message, ErrorCode errorCode, HttpStatusCode httpStatusCode) : base(message)
		{
			ErrorCode = errorCode;
			HttpStatusCode = httpStatusCode;
		}

		public ApiException(string message, ErrorCode errorCode, HttpStatusCode httpStatusCode, Exception inner) : base(
			message, inner)
		{
			ErrorCode = errorCode;
			HttpStatusCode = httpStatusCode;
		}

		protected ApiException(
			SerializationInfo info,
			StreamingContext context) : base(info, context)
		{
			ErrorCode = (ErrorCode)info.GetValue(nameof(ErrorCode), typeof(ErrorCode));
			HttpStatusCode = (HttpStatusCode)info.GetValue(nameof(HttpStatusCode), typeof(HttpStatusCode));
		}

		public HttpStatusCode HttpStatusCode { get; init; }
		public ErrorCode ErrorCode { get; init; }

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);

			info.AddValue(nameof(ErrorCode), ErrorCode, typeof(ErrorCode));
			info.AddValue(nameof(HttpStatusCode), HttpStatusCode, typeof(HttpStatusCode));
		}
	}
}