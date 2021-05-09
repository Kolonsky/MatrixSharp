using System.Text.Json.Serialization;
using MatrixSharp.Entities.Events.MatrixEventContent;
using MatrixSharp.Tools;

namespace MatrixSharp.Entities.Events
{
	/// <summary>
	///     State event.
	/// </summary>
	[JsonConverter(typeof(ConverterTools.EventConverter<StateEvent>))]
	public class StateEvent : RoomEvent
	{
		/// <inheritdoc cref="StateEvent" />
		public StateEvent(BaseMatrixEventContent content, string type, string eventId, string sender,
			ulong originServerTs,
			string roomId,
			string stateKey) : base(content, type, eventId, sender, originServerTs, roomId)
		{
			StateKey = stateKey;
		}

		/// <summary>
		///     A unique key which defines the overwriting semantics for this piece of room state. This value is often a
		///     zero-length string. The presence of this key makes this event a State Event. State keys starting with an @ are
		///     reserved for referencing user IDs, such as room members. With the exception of a few events, state events set with
		///     a given user's ID as the state key MUST only be set by that user.
		/// </summary>
		[JsonPropertyName("state_key")]
		public string StateKey { get; }

		/// <summary>
		///     Optional. The previous content for this event. If there is no previous content, this key will be missing.
		/// </summary>
		[JsonPropertyName("prev_content")]
		public EventContent? PreviousContent { get; set; }

		public class EventContent
		{
			public EventContent(MembershipEnum membership)
			{
				Membership = membership;
			}

			/// <summary>
			///     The avatar URL for this user, if any.
			/// </summary>
			[JsonPropertyName("avatar_url")]
			public string? AvatarUrl { get; set; }

			/// <summary>
			///     The display name for this user, if any.
			/// </summary>
			[JsonPropertyName("displayname")]
			public string[]? DisplayName { get; set; }

			/// <summary>
			///     Flag indicating if the room containing this event was created with the intention of being a direct chat.
			/// </summary>
			[JsonPropertyName("is_direct")]
			public bool? IsDirect { get; set; }

			/// <summary>
			///     The membership state of the user. One of: ["invite", "join", "knock", "leave", "ban"]
			/// </summary>
			public MembershipEnum Membership { get; }

			/// <summary>
			///     Optional user-supplied text for why their membership has changed.
			/// </summary>
			/// <remarks>
			///     For kicks and bans, this is typically the reason for the kick or ban. For other membership changes, this is a
			///     way for the user to communicate their intent without having to send a message to the room, such as in a case where
			///     Bob rejects an invite from Alice about an upcoming concert, but can’t make it that day.
			/// </remarks>
			[JsonPropertyName("reason")]
			public string? Reason { get; set; }

			// TODO: Invite field
		}

		/// <summary>
		///     The membership state of the user.
		/// </summary>
		public enum MembershipEnum
		{
			/// <summary>
			///     User invited.
			/// </summary>
			Invite,

			/// <summary>
			///     User joined.
			/// </summary>
			Join,

			/// <summary>
			///     Knock-knock. Who's there?
			/// </summary>
			Knock,

			/// <summary>
			///     User leaved.
			/// </summary>
			Leave,

			/// <summary>
			///     User banned.
			/// </summary>
			Ban
		}
	}
}