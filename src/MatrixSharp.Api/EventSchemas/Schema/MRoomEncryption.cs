using System.Runtime.Serialization;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <inheritdoc cref="RoomEncryptionEventContent" />
	[MatrixEventType("m.room.encryption")]
	public record RoomEncryptionEvent : StateEvent<RoomEncryptionEventContent>
	{
		/// <inheritdoc cref="RoomEncryptionEvent" />
		/// <param name="stateKey"> A zero-length string.</param>
		public RoomEncryptionEvent(RoomEncryptionEventContent content, string type, string eventId, string sender,
			long originServerTs, string stateKey, string roomId) : base(content, type, eventId, sender, originServerTs,
			stateKey, roomId)
		{
		}
	}

	/// <summary>
	///     Defines how messages sent in this room should be encrypted.
	/// </summary>
	/// <param name="Algorithm">
	///     The encryption algorithm to be used to encrypt messages sent in this
	///     room.
	/// </param>
	public record RoomEncryptionEventContent(
		RoomEncryptedEventContent.AlgorithmEnum Algorithm
	) : IEventContent
	{
		/// <summary>
		///     How long the session should be used before changing it. ``604800000``
		///     (a week) is the recommended default.
		/// </summary>
		public int? RotationPeriodMs { get; init; }

		/// <summary>
		///     How many messages should be sent before changing the session. ``100`` is the
		///     recommended default.
		/// </summary>
		public int? RotationPeriodMsgs { get; init; }

		public enum AlgorithmEnum
		{
			[EnumMember(Value = "m.megolm.v1.aes-sha2")]
			MMegolmV1AesSha2
		}
	}
}