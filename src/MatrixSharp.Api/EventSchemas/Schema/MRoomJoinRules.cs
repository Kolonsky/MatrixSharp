using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	internal class MRoomJoinRules
	{
	}

	/// <inheritdoc cref="RoomJoinRulesEventContent" />
	[MatrixEventType("m.room.join_rules")]
	public record RoomJoinRulesEvent : StateEvent<RoomJoinRulesEventContent>
	{
		/// <inheritdoc cref="RoomJoinRulesEvent" />
		/// <param name="stateKey"> A zero-length string.</param>
		public RoomJoinRulesEvent(RoomJoinRulesEventContent content, string type, string eventId, string sender,
			long originServerTs, string stateKey, string roomId) : base(content, type, eventId, sender, originServerTs,
			stateKey, roomId)
		{
		}
	}

	/// <summary>
	///     A room may be ``public`` meaning anyone can join the room without any prior action. Alternatively, it can be
	///     ``invite`` meaning that a user who wishes to join the room must first receive an invite to the room from someone
	///     already inside of the room. Currently, ``knock`` and ``private`` are reserved keywords which are not implemented.
	/// </summary>
	public record RoomJoinRulesEventContent(
		RoomJoinRulesEventContent.JoinRuleEnum JoinRule
	) : IEventContent
	{
		/// <summary>
		///     The type of rules used for users wishing to join this room.
		/// </summary>
		public enum JoinRuleEnum
		{
			Public,
			Knock,
			Invite,
			Private
		}
	}
}