using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MatrixSharp.Entities.Events.MatrixEventContent
{
	/// <summary>
	///     A room may be public meaning anyone can join the room without any prior action. Alternatively, it can be invite
	///     meaning that a user who wishes to join the room must first receive an invite to the room from someone already
	///     inside of the room. Currently, knock and private are reserved keywords which are not implemented.
	/// </summary>
	[MatrixEvent("m.room.join_rules")]
	public class MRoomJoinRules : BaseMatrixEventContent
	{
		/// <inheritdoc cref="MRoomJoinRules" />
		public MRoomJoinRules(JoinRuleEnum joinRule)
		{
			JoinRule = joinRule;
		}

		/// <inheritdoc cref="JoinRuleEnum" />
		[JsonPropertyName("join_rule")]
		public JoinRuleEnum JoinRule { get; }

		#region Enums

		/// <summary>
		///     The type of rules used for users wishing to join this room.
		/// </summary>
		public enum JoinRuleEnum
		{
			/// <summary>
			///     Anyone can join the room without any prior action.
			/// </summary>
			[EnumMember(Value = "public")] Public,

			/// <summary>
			///     A user who wishes to join the room must first receive an invite to the room from someone already inside of the
			///     room.
			/// </summary>
			[EnumMember(Value = "invite")] Invite,

			/// <summary>
			///     A users are able to ask for permission to join the room, where they are either allowed (invited) or denied
			///     (kicked/banned) access.
			/// </summary>
			/// <remarks>
			///     Join rules of <see cref="Knock" /> are otherwise the same as <see cref="Invite" />: the user needs an explicit
			///     invite to join the room.
			/// </remarks>
			[EnumMember(Value = "knock")] Knock,

			/// <summary>
			///     Not implemented
			/// </summary>
			[Obsolete]
			[EnumMember(Value = "private")]
			Private
		}

		#endregion
	}
}