using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <inheritdoc cref="RoomGuestAccessEventContent" />
	[MatrixEventType("m.room.guest_access")]
	public record RoomGuestAccessEvent : StateEvent<RoomGuestAccessEventContent>
	{
		/// <inheritdoc cref="RoomGuestAccessEvent" />
		/// <param name="stateKey"> A zero-length string.</param>
		public RoomGuestAccessEvent(RoomGuestAccessEventContent content, string type, string eventId, string sender,
			long originServerTs, string stateKey, string roomId) : base(content, type, eventId, sender, originServerTs,
			stateKey, roomId)
		{
		}
	}

	/// <summary>
	///     This event controls whether guest users are allowed to join rooms. If this event is absent, servers should act as
	///     if it is present and has the guest_access value "forbidden".
	/// </summary>
	public record RoomGuestAccessEventContent(
		RoomGuestAccessEventContent.GuestAccessEnum GuestAccess
	) : IEventContent
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