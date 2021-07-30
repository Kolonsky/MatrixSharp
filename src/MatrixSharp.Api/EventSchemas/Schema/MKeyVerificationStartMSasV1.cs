using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     Begins a SAS key verification process using the ``m.sas.v1`` method. Typically sent as a `to-device`_ event.
	/// </summary>
	[MatrixEventType("m.key.verification.start", "m.sas.v1")]
	public record KeyVerificationStartMSasV1Event : Event<KeyVerificationStartMSasV1Event.ContentProperty>
	{
		/// <inheritdoc cref="KeyVerificationStartMSasV1Event" />
		public KeyVerificationStartMSasV1Event(ContentProperty content, string type) : base(
			content, type)
		{
		}

		/// <param name="FromDevice"> The device ID which is initiating the process.</param>
		/// <param name="TransactionId">
		///     An opaque identifier for the verification process. Must be unique
		///     with respect to the devices involved. Must be the same as the
		///     ``transaction_id`` given in the ``m.key.verification.request``
		///     if this process is originating from a request.
		/// </param>
		/// <param name="KeyAgreementProtocols">
		///     The key agreement protocols the sending device understands. Must
		///     include at least ``curve25519``.
		/// </param>
		/// <param name="Hashes">
		///     The hash methods the sending device understands. Must include at least
		///     ``sha256``.
		/// </param>
		/// <param name="MessageAuthenticationCodes">
		///     The message authentication codes that the sending device understands.
		///     Must include at least ``hkdf-hmac-sha256``.
		/// </param>
		public record ContentProperty(
			string FromDevice,
			string TransactionId,
			string[] KeyAgreementProtocols,
			string[] Hashes,
			string[] MessageAuthenticationCodes,
			ContentProperty.ShortAuthenticationStringEnum ShortAuthenticationString
		) : IContentProperty
		{
			/// <summary>
			///     The verification method to use.
			/// </summary>
			public const string Method = "m.sas.v1";

			/// <summary>
			///     The SAS methods the sending device (and the sending device's user)
			///     understands. Must include at least ``decimal``. Optionally can include
			///     ``emoji``.
			/// </summary>
			public enum ShortAuthenticationStringEnum
			{
				Decimal,
				Emoji
			}
		}
	}
}