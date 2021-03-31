using System.Text.Json.Serialization;

namespace MatrixSharp.Entities.EventContentTypes
{
	/// <summary>
	///     A room may be public meaning anyone can join the room without any prior action. Alternatively, it can be invite
	///     meaning that a user who wishes to join the room must first receive an invite to the room from someone already
	///     inside of the room. Currently, knock and private are reserved keywords which are not implemented.
	/// </summary>
	public class MRoomJoinRules
	{
		/// <inheritdoc cref="MRoomJoinRules" />
		public MRoomJoinRules(JoinRuleEnum joinRule)
		{
			JoinRule = joinRule;
		}

		/// <summary>
		///     The type of rules used for users wishing to join this room.
		/// </summary>
		[JsonPropertyName("join_rule")]
		public JoinRuleEnum JoinRule { get; }
	}

	public enum JoinRuleEnum
	{
		Public,
		Knock,
		Invite,
		Private
	}
}