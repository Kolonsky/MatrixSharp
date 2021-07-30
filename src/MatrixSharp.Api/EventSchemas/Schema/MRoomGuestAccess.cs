using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     This event controls whether guest users are allowed to join rooms. If this event is absent, servers should act as
	///     if it is present and has the guest_access value "forbidden".
	/// </summary>
	[MatrixEventType("m.room.guest_access")]
	public record RoomGuestAccessEvent : StateEvent<RoomGuestAccessEvent.ContentProperty>
	{
		/// <inheritdoc cref="RoomGuestAccessEvent" />
		/// <param name="stateKey"> A zero-length string.</param>
		public RoomGuestAccessEvent(ContentProperty content, string type, string eventId, string sender,
			long originServerTs, string stateKey, string roomId) : base(content, type, eventId, sender, originServerTs,
			stateKey, roomId)
		{
		}

		public record ContentProperty(
			ContentProperty.GuestAccessEnum GuestAccess
		) : IContentProperty
		{
			/// <summary>
			///     Whether guests can join the room.
			/// </summary>
			public enum GuestAccessEnum
			{
				CanJoin,
				Forbidden
			}
		}
	}
}