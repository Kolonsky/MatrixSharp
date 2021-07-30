using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     Begins a SAS key verification process using the ``m.sas.v1`` method. Typically sent as a `to-device`_ event.
	/// </summary>
	[MatrixEventType(TYPE, METHOD)]
	public sealed record KeyVerificationStartMSasV1Event : KeyVerificationStartEvent
	{
		private const string METHOD = "m.sas.v1";

		/// <inheritdoc cref="KeyVerificationStartMSasV1Event" />
		public KeyVerificationStartMSasV1Event(ContentProperty content) : base(content)
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
		public new record ContentProperty(
			string FromDevice,
			string TransactionId,
			string[] KeyAgreementProtocols,
			string[] Hashes,
			string[] MessageAuthenticationCodes,
			ContentProperty.ShortAuthenticationStringEnum ShortAuthenticationString
		) : KeyVerificationStartEvent.ContentProperty(FromDevice, TransactionId, METHOD)
		{
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