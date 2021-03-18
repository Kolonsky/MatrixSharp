using System;
using System.Net.Http;
using System.Runtime.Serialization;

namespace MatrixSharp.Exceptions
{
	/// <summary>
	///     Represents an exception thrown when the response from the server was valid but did not meet the Matrix
	///     specification.
	/// </summary>
	[Serializable]
	public class UnexpectedApiException : Exception
	{
		/// <inheritdoc cref="UnexpectedApiException"/>
		public UnexpectedApiException(string message, HttpResponseMessage response) : base(message)
		{
			Response = response;
		}

		/// <inheritdoc cref="UnexpectedApiException"/>
		public UnexpectedApiException(string message, HttpResponseMessage response, Exception inner) : base(message,
			inner)
		{
			Response = response;
		}

#nullable disable
		/// <summary>
		///     Used to serialize exception.
		/// </summary>
		protected UnexpectedApiException(
			SerializationInfo info,
			StreamingContext context) : base(info, context)
		{
			Response = (HttpResponseMessage) info.GetValue(nameof(Response), typeof(HttpResponseMessage));
		}

		/// <inheritdoc cref="HttpResponseMessage"/>
		public HttpResponseMessage Response { get; set; }

		/// <summary>
		///     Used to deserialize exception.
		/// </summary>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);

			info.AddValue(nameof(Response), Response, typeof(HttpResponseMessage));
		}
	}
}