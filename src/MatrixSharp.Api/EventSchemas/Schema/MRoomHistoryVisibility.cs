using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     This event controls whether a user can see the events that happened in a room from before they joined.
	/// </summary>
	[MatrixEventType(TYPE)]
	public record RoomHistoryVisibilityEvent : StateEvent<RoomHistoryVisibilityEvent.ContentProperty>
	{
		private const string TYPE = "m.room.history_visibility";

		/// <inheritdoc cref="RoomHistoryVisibilityEvent" />
		/// <param name="stateKey"> A zero-length string.</param>
		public RoomHistoryVisibilityEvent(ContentProperty content, string eventId, string sender, long originServerTs,
			string stateKey, string roomId) : base(content, TYPE, eventId, sender, originServerTs, stateKey, roomId)
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