using System.Runtime.Serialization;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     This event type is used to exchange keys for end-to-end encryption. Typically
	///     it is encrypted as an ``m.room.encrypted`` event, then sent as a `to-device`_ event.
	/// </summary>
	[MatrixEventType("m.room_key")]
	public record RoomKeyEvent : Event<RoomKeyEvent.ContentProperty>
	{
		/// <inheritdoc cref="RoomKeyEvent" />
		public RoomKeyEvent(ContentProperty content, string type) : base(content, type)
		{
		}

		/// <param name="Algorithm"> The encryption algorithm the key in this event is to be used with.</param>
		/// <param name="RoomId"> The room where the key is used.</param>
		/// <param name="SessionId"> The ID of the session that the key is for.</param>
		/// <param name="SessionKey"> The key to be exchanged.</param>
		public record ContentProperty(
			ContentProperty.AlgorithmEnum Algorithm,
			string RoomId,
			string SessionId,
			string SessionKey
		) : IContentProperty
		{
			/// <summary>
			///     The encryption algorithm the key in this event is to be used with.
			/// </summary>
			public enum AlgorithmEnum
			{
				[EnumMember(Value = "m.megolm.v1.aes-sha2")]
				MMegolmV1AesSha2
			}
		}
	}
}