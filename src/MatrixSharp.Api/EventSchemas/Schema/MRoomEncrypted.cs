using System.Runtime.Serialization;
using System.Text.Json;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary> This event type is used when sending encrypted events.</summary>
	[MatrixEventType(TYPE)]
	public record RoomEncryptedEvent : Event<RoomEncryptedEvent.ContentProperty>
	{
		private const string TYPE = "m.room.encrypted";

		/// <inheritdoc cref="RoomEncryptedEvent" />
		public RoomEncryptedEvent(ContentProperty content) : base(content, TYPE)
		{
		}

		/// <param name="Algorithm">
		///     The encryption algorithm used to encrypt this event. The
		///     value of this field determines which other properties will be
		///     present.
		/// </param>
		/// <param name="Ciphertext">
		///     The encrypted content of the event. Either the encrypted payload
		///     itself, in the case of a Megolm event, or a map from the recipient
		///     Curve25519 identity key to ciphertext information, in the case of an
		///     Olm event.
		/// </param>
		/// <param name="SenderKey"> </param>
		public record ContentProperty(
			ContentProperty.AlgorithmEnum Algorithm,
			JsonElement Ciphertext,
			string SenderKey
		) : IContentProperty
		{
			/// <summary>
			///     The ID of the sending device. Required with Megolm.
			/// </summary>
			public string? DeviceId { get; init; }

			/// <summary>
			///     The ID of the session used to encrypt the message. Required with
			///     Megolm.
			/// </summary>
			public string? SessionId { get; init; }

			public enum AlgorithmEnum
			{
				[EnumMember(Value = "m.olm.v1.curve25519-aes-sha2")]
				MOlmV1Curve25519AesSha2,

				[EnumMember(Value = "m.megolm.v1.aes-sha2")]
				MMegolmV1AesSha2
			}
		}
	}
}