using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <inheritdoc cref="RoomHistoryVisibilityEventContent" />
	[MatrixEventType("m.room.history_visibility")]
	public record RoomHistoryVisibilityEvent : StateEvent<RoomHistoryVisibilityEventContent>
	{
		/// <inheritdoc cref="RoomHistoryVisibilityEvent" />
		/// <param name="stateKey"> A zero-length string.</param>
		public RoomHistoryVisibilityEvent(RoomHistoryVisibilityEventContent content, string type, string eventId,
			string sender, long originServerTs, string stateKey, string roomId) : base(content, type, eventId, sender,
			originServerTs, stateKey, roomId)
		{
		}
	}

	/// <summary>
	///     This event controls whether a user can see the events that happened in a room from before they joined.
	/// </summary>
	public record RoomHistoryVisibilityEventContent(
		RoomHistoryVisibilityEventContent.HistoryVisibilityEnum HistoryVisibility
	) : IEventContent
	{
		public enum HistoryVisibilityEnum
		{
			Invited,
			Joined,
			Shared,
			WorldReadable
		}
	}
}