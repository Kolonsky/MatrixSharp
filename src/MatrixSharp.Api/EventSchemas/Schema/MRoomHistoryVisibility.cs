using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     This event controls whether a user can see the events that happened in a room from before they joined.
	/// </summary>
	[MatrixEventType("m.room.history_visibility")]
	public record RoomHistoryVisibilityEvent : StateEvent<RoomHistoryVisibilityEvent.ContentProperty>
	{
		/// <inheritdoc cref="RoomHistoryVisibilityEvent" />
		/// <param name="stateKey"> A zero-length string.</param>
		public RoomHistoryVisibilityEvent(ContentProperty content, string type, string eventId,
			string sender, long originServerTs, string stateKey, string roomId) : base(content, type, eventId, sender,
			originServerTs, stateKey, roomId)
		{
		}

		public record ContentProperty(
			ContentProperty.HistoryVisibilityEnum HistoryVisibility
		) : IContentProperty
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
}