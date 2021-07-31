using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     This event is used to "pin" particular events in a room for other participants to review later. The order of the
	///     pinned events is guaranteed and based upon the order supplied in the event. Clients should be aware that the
	///     current user may not be able to see some of the events pinned due to visibility settings in the room. Clients are
	///     responsible for determining if a particular event in the pinned list is displayable, and have the option to not
	///     display it if it cannot be pinned in the client.
	/// </summary>
	[MatrixEventType(TYPE)]
	public record RoomPinnedEvents : StateEvent<RoomPinnedEvents.ContentProperty>
	{
		private const string TYPE = "m.room.pinned_events";

		/// <inheritdoc cref="RoomPinnedEvents" />
		/// <param name="stateKey"> A zero-length string.</param>
		public RoomPinnedEvents(ContentProperty content, string eventId, string sender, long originServerTs,
			string stateKey, string roomId) : base(content, TYPE, eventId, sender, originServerTs, stateKey, roomId)
		{
		}

		/// <param name="Pinned"> An ordered list of event IDs to pin.</param>
		public record ContentProperty(
			string[] Pinned
		) : IContentProperty;
	}
}