using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     Requests a key verification with another user's devices. Typically sent as a
	///     `to-device`_ event.
	/// </summary>
	[MatrixEventType(TYPE)]
	public record KeyVerificationRequestEvent : Event<KeyVerificationRequestEvent.ContentProperty>
	{
		private const string TYPE = "m.key.verification.request";

		/// <inheritdoc cref="KeyVerificationRequestEvent" />
		public KeyVerificationRequestEvent(ContentProperty content) : base(content, TYPE)
		{
		}

		/// <param name="FromDevice"> The device ID which is initiating the request.</param>
		/// <param name="TransactionId">
		///     An opaque identifier for the verification request. Must be unique
		///     with respect to the devices involved.
		/// </param>
		/// <param name="Methods"> The verification methods supported by the sender.</param>
		/// <param name="Timestamp">
		///     The POSIX timestamp in milliseconds for when the request was made. If
		///     the request is in the future by more than 5 minutes or more than 10
		///     minutes in the past, the message should be ignored by the receiver.
		/// </param>
		public record ContentProperty(
			string FromDevice,
			string TransactionId,
			string[] Methods,
			long Timestamp
		) : IContentProperty;
	}
}