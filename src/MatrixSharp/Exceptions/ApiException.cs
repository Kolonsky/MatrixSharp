using System;
using System.Net;
using System.Runtime.Serialization;
using MatrixSharp.Entities;

namespace MatrixSharp.Exceptions
{
	/// <summary>
	///     Represents errors occurred at the Matrix API level.
	/// </summary>
	[Serializable]
	public class ApiException : Exception
	{
		/// <inheritdoc cref="ApiException" />
		public ApiException(string message, StandardErrorResponse errorResponse, HttpStatusCode httpStatusCode) :
			base(message)
		{
			ErrorResponse = errorResponse;
			HttpStatusCode = httpStatusCode;
		}

		/// <inheritdoc cref="ApiException" />
		public ApiException(string message, StandardErrorResponse errorResponse, HttpStatusCode httpStatusCode,
			Exception inner) : base(
			message, inner)
		{
			ErrorResponse = errorResponse;
			HttpStatusCode = httpStatusCode;
		}

#nullable disable
		/// <summary>
		///     Used to serialize exception.
		/// </summary>
		protected ApiException(
			SerializationInfo info,
			StreamingContext context) : base(info, context)
		{
			ErrorResponse = (StandardErrorResponse) info.GetValue(nameof(ErrorResponse), typeof(StandardErrorResponse));
			HttpStatusCode = (HttpStatusCode) info.GetValue(nameof(HttpStatusCode), typeof(HttpStatusCode));
		}


		/// <inheritdoc cref="System.Net.HttpStatusCode" />
		public HttpStatusCode HttpStatusCode { get; set; }

		/// <inheritdoc cref="StandardErrorResponse" />
		public StandardErrorResponse ErrorResponse { get; set; }

		/// <summary>
		///     Used to deserialize exception.
		/// </summary>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);

			info.AddValue(nameof(ErrorResponse), ErrorResponse, typeof(StandardErrorResponse));
			info.AddValue(nameof(HttpStatusCode), HttpStatusCode, typeof(HttpStatusCode));
		}
	}
}