using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     A room may be ``public`` meaning anyone can join the room without any prior action. Alternatively, it can be
	///     ``invite`` meaning that a user who wishes to join the room must first receive an invite to the room from someone
	///     already inside of the room. Currently, ``knock`` and ``private`` are reserved keywords which are not implemented.
	/// </summary>
	[MatrixEventType(TYPE)]
	public record RoomJoinRulesEvent : StateEvent<RoomJoinRulesEvent.ContentProperty>
	{
		private const string TYPE = "m.room.join_rules";

		/// <inheritdoc cref="RoomJoinRulesEvent" />
		/// <param name="stateKey"> A zero-length string.</param>
		public RoomJoinRulesEvent(ContentProperty content, string eventId, string sender, long originServerTs,
			string stateKey, string roomId) : base(content, TYPE, eventId, sender, originServerTs, stateKey, roomId)
		{
		}

		public record ContentProperty(
			ContentProperty.JoinRuleEnum JoinRule
		) : IContentProperty
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
}