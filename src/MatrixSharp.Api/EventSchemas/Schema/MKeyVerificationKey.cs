using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <inheritdoc cref="KeyVerificationKeyEventContent" />
	[MatrixEventType("m.key.verification.key")]
	public record KeyVerificationKeyEvent : Event<KeyVerificationKeyEventContent>
	{
		/// <inheritdoc cref="KeyVerificationKeyEvent" />
		public KeyVerificationKeyEvent(KeyVerificationKeyEventContent content, string type) : base(content, type)
		{
		}
	}

	/// <summary>
	///     Sends the ephemeral public key for a device to the partner device. Typically sent as a
	///     `to-device`_ event.
	/// </summary>
	/// <param name="TransactionId">
	///     An opaque identifier for the verification process. Must be the same as
	///     the one used for the ``m.key.verification.start`` message.
	/// </param>
	/// <param name="Key"> The device's ephemeral public key, encoded as unpadded base64.</param>
	public record KeyVerificationKeyEventContent(
		string TransactionId,
		string Key
	) : IEventContent;
}