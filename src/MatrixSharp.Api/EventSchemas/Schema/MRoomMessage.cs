using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     This event is used when sending messages in a room. Messages are not limited to be text. The ``msgtype`` key
	///     outlines the type of message, e.g. text, audio, image, video, etc. The ``body`` key is text and MUST be used with
	///     every kind of ``msgtype`` as a fallback mechanism for when a client cannot render a message. This allows clients to
	///     display *something* even if it is just plain text.
	/// </summary>
	[MatrixEventType("m.room.message")]
	public record RoomMessageEvent : RoomEvent<RoomMessageEvent.ContentProperty>
	{
		/// <inheritdoc cref="RoomMessageEvent" />
		public RoomMessageEvent(ContentProperty content, string type, string eventId, string sender,
			long originServerTs,
			string roomId) : base(content, type, eventId, sender, originServerTs, roomId)
		{
		}

		/// <param name="Body"> The textual representation of this message.</param>
		/// <param name="Msgtype"> The type of message, e.g. ``m.image``, ``m.text``</param>
		public record ContentProperty(
			string Body,
			string Msgtype
		) : IContentProperty;
	}
}