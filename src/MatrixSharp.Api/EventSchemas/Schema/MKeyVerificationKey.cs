using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     Sends the ephemeral public key for a device to the partner device. Typically sent as a
	///     `to-device`_ event.
	/// </summary>
	[MatrixEventType(TYPE)]
	public record KeyVerificationKeyEvent : Event<KeyVerificationKeyEvent.ContentProperty>
	{
		private const string TYPE = "m.key.verification.key";

		/// <inheritdoc cref="KeyVerificationKeyEvent" />
		public KeyVerificationKeyEvent(ContentProperty content) : base(content, TYPE)
		{
		}

		/// <param name="TransactionId">
		///     An opaque identifier for the verification process. Must be the same as
		///     the one used for the ``m.key.verification.start`` message.
		/// </param>
		/// <param name="Key"> The device's ephemeral public key, encoded as unpadded base64.</param>
		public record ContentProperty(
			string TransactionId,
			string Key
		) : IContentProperty;
	}
}