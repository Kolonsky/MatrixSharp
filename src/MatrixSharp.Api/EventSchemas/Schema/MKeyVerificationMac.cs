using System.Collections.Generic;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <inheritdoc cref="KeyVerificationKeyEventContent" />
	[MatrixEventType("m.key.verification.mac")]
	public record KeyVerificationMacEvent : Event<KeyVerificationKeyEventContent>
	{
		/// <inheritdoc cref="KeyVerificationKeyEvent" />
		public KeyVerificationMacEvent(KeyVerificationKeyEventContent content, string type) : base(content, type)
		{
		}
	}

	/// <summary>
	///     Sends the MAC of a device's key to the partner device. Typically sent as a
	///     `to-device`_ event.
	/// </summary>
	/// <param name="TransactionId">
	///     An opaque identifier for the verification process. Must be the same as
	///     the one used for the ``m.key.verification.start`` message.
	/// </param>
	/// <param name="Mac">
	///     A map of the key ID to the MAC of the key, using the algorithm in the
	///     verification process. The MAC is encoded as unpadded base64.
	/// </param>
	/// <param name="Keys">
	///     The MAC of the comma-separated, sorted, list of key IDs given in the ``mac``
	///     property, encoded as unpadded base64.
	/// </param>
	public record KeyVerificationMacEventContent(
		string TransactionId,
		IDictionary<string, string> Mac,
		string Keys
	) : IEventContent;
}