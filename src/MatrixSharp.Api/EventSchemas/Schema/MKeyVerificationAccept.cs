using System.Runtime.Serialization;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <inheritdoc cref="KeyVerificationAcceptEventContent" />
	[MatrixEventType("m.key.verification.accept")]
	public record KeyVerificationAcceptEvent : Event<KeyVerificationAcceptEventContent>
	{
		/// <inheritdoc cref="KeyVerificationAcceptEvent" />
		public KeyVerificationAcceptEvent(KeyVerificationAcceptEventContent content, string type) : base(content, type)
		{
		}
	}

	/// <summary>
	///     Accepts a previously sent ``m.key.verification.start`` message. Typically sent as a
	///     `to-device`_ event.
	/// </summary>
	/// <param name="TransactionId">
	///     An opaque identifier for the verification process. Must be the same as
	///     the one used for the ``m.key.verification.start`` message.
	/// </param>
	/// <param name="Method"> The verification method to use.</param>
	/// <param name="KeyAgreementProtocol">
	///     The key agreement protocol the device is choosing to use, out of the
	///     options in the ``m.key.verification.start`` message.
	/// </param>
	/// <param name="Hash">
	///     The hash method the device is choosing to use, out of the options in
	///     the ``m.key.verification.start`` message.
	/// </param>
	/// <param name="MessageAuthenticationCode">
	///     The message authentication code the device is choosing to use, out of
	///     the options in the ``m.key.verification.start`` message.
	/// </param>
	/// <param name="ShortAuthenticationString">
	///     The SAS methods both devices involved in the verification process
	///     understand. Must be a subset of the options in the ``m.key.verification.start``
	///     message.
	/// </param>
	/// <param name="Commitment">
	///     The hash (encoded as unpadded base64) of the concatenation of the device's
	///     ephemeral public key (encoded as unpadded base64) and the canonical JSON
	///     representation of the ``m.key.verification.start`` message.
	/// </param>
	public record KeyVerificationAcceptEventContent(
		string TransactionId,
		KeyVerificationAcceptEventContent.MethodEnum Method,
		string KeyAgreementProtocol,
		string Hash,
		string MessageAuthenticationCode,
		KeyVerificationAcceptEventContent.ShortAuthenticationStringEnum[] ShortAuthenticationString,
		string Commitment
	) : IEventContent
	{
		public enum MethodEnum
		{
			[EnumMember(Value = "m.sas.v1")] MSasV1
		}

		public enum ShortAuthenticationStringEnum
		{
			Decimal,
			Emoji
		}
	}
}