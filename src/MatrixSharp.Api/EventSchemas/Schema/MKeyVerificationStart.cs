using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <inheritdoc cref="KeyVerificationStartEventContent" />
	[MatrixEventType("m.key.verification.start")]
	public record KeyVerificationStartEvent : Event<KeyVerificationStartEventContent>
	{
		/// <inheritdoc cref="KeyVerificationStartEvent" />
		public KeyVerificationStartEvent(KeyVerificationStartEventContent content, string type) : base(content, type)
		{
		}
	}

	/// <summary>
	///     Begins a key verification process. Typically sent as a `to-device`_ event. The ``method``
	///     field determines the type of verification. The fields in the event will differ depending
	///     on the ``method``. This definition includes fields that are in common among all variants.
	/// </summary>
	/// <param name="FromDevice"> The device ID which is initiating the process.</param>
	/// <param name="TransactionId">
	///     An opaque identifier for the verification process. Must be unique
	///     with respect to the devices involved. Must be the same as the
	///     ``transaction_id`` given in the ``m.key.verification.request``
	///     if this process is originating from a request.
	/// </param>
	/// <param name="Method"> The verification method to use.</param>
	public record KeyVerificationStartEventContent(
		string FromDevice,
		string TransactionId,
		string Method
	) : IEventContent
	{
		/// <summary>
		///     Optional method to use to verify the other user's key with. Applicable
		///     when the ``method`` chosen only verifies one user's key. This field will
		///     never be present if the ``method`` verifies keys both ways.
		/// </summary>
		public string? NextMethod { get; init; }
	}
}