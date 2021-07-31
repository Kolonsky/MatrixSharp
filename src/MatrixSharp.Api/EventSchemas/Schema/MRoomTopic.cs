using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     A topic is a short message detailing what is currently being discussed in the room. It can also be used as a way to
	///     display extra information about the room, which may not be suitable for the room name. The room topic can also be
	///     set when creating a room using ``/createRoom`` with the ``topic`` key.
	/// </summary>
	[MatrixEventType(TYPE)]
	public record RoomTopicEvent : StateEvent<RoomTopicEvent.ContentProperty>
	{
		private const string TYPE = "m.room.topic";

		/// <inheritdoc cref="RoomTopicEvent" />
		/// <param name="stateKey"> A zero-length string.</param>
		public RoomTopicEvent(ContentProperty content, string eventId, string sender, long originServerTs,
			string stateKey, string roomId) : base(content, TYPE, eventId, sender, originServerTs, stateKey, roomId)
		{
		}

		/// <param name="Topic"> The topic text.</param>
		public record ContentProperty(
			string Topic
		) : IContentProperty;
	}
}