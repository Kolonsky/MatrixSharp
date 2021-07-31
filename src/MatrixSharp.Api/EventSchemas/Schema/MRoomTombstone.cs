using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     Indication that the room has been upgraded.
	/// </summary>
	/// <remarks>
	///     A state event signifying that a room has been upgraded to a different room version, and that clients should go
	///     there.
	/// </remarks>
	[MatrixEventType(TYPE)]
	public record RoomTombstoneEvent : StateEvent<RoomTombstoneEvent.ContentProperty>
	{
		private const string TYPE = "m.room.tombstone";

		/// <inheritdoc cref="RoomTombstoneEvent" />
		/// <param name="stateKey"> A zero-length string.</param>
		public RoomTombstoneEvent(ContentProperty content, string eventId, string sender, long originServerTs,
			string stateKey, string roomId) : base(content, TYPE, eventId, sender, originServerTs, stateKey, roomId)
		{
		}

		/// <param name="Body"> A server-defined message.</param>
		/// <param name="ReplacementRoom"> The new room the client should be visiting.</param>
		public record ContentProperty(
			string Body,
			string ReplacementRoom
		) : IContentProperty;
	}
}