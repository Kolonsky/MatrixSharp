using System;
using System.Net;
using System.Runtime.Serialization;

namespace MatrixSharp.Net.Api.Exceptions
{
	public sealed class ApiRatelimitedException : ApiException
	{
		public ApiRatelimitedException(string message, ErrorCode errorCode, TimeSpan retryAfter,
			HttpStatusCode httpStatusCode) : base(message, errorCode, httpStatusCode)
		{
			RetryAfter = retryAfter;
		}

		public ApiRatelimitedException(string message, ErrorCode errorCode, TimeSpan retryAfter,
			HttpStatusCode httpStatusCode, Exception inner) : base(message, errorCode, httpStatusCode, inner)
		{
			RetryAfter = retryAfter;
		}

		private ApiRatelimitedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			RetryAfter = (TimeSpan) info.GetValue(nameof(RetryAfter), typeof(TimeSpan));
		}

		public TimeSpan RetryAfter { get; init; }

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);

			info.AddValue(nameof(RetryAfter), RetryAfter, typeof(TimeSpan));
		}
	}
}