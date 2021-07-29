using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <inheritdoc cref="KeyVerificationRequestEventContent" />
	[MatrixEventType("m.key.verification.request")]
	public record KeyVerificationRequestEvent : Event<KeyVerificationRequestEventContent>
	{
		/// <inheritdoc cref="KeyVerificationRequestEvent" />
		public KeyVerificationRequestEvent(KeyVerificationRequestEventContent content, string type) : base(content,
			type)
		{
		}
	}

	/// <summary>
	///     Requests a key verification with another user's devices. Typically sent as a
	///     `to-device`_ event.
	/// </summary>
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
	public record KeyVerificationRequestEventContent(
		string FromDevice,
		string TransactionId,
		string[] Methods,
		long Timestamp
	) : IEventContent;
}