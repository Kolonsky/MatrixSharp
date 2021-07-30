using System.Collections.Generic;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     Adjusts the membership state for a user in a room. It is preferable to use the membership APIs (``/rooms/&lt;room
	///     id&gt;/invite`` etc) when performing membership actions rather than adjusting the state directly as there are a
	///     restricted set of valid transformations. For example, user A cannot force user B to join a room, and trying to
	///     force this state change directly will fail.
	/// </summary>
	[MatrixEventType(TYPE)]
	public record RoomMemberEvent : StateEvent<RoomMemberEvent.ContentProperty>
	{
		private const string TYPE = "m.room.member";

		/// <inheritdoc cref="RoomMemberEvent" />
		/// <param name="stateKey">
		///     The ``user_id`` this membership event relates to. In all cases except for when ``membership`` is
		///     ``join``, the user ID sending the event does not need to match the user ID in the ``state_key``,
		///     unlike other events. Regular authorization rules still apply.
		/// </param>
		public RoomMemberEvent(ContentProperty content, string eventId, string sender,
			long originServerTs, string stateKey, string roomId) : base(content, TYPE, eventId, sender, originServerTs,
			stateKey, roomId)
		{
		}

		public record ContentProperty(
			ContentProperty.MembershipEnum Membership
		) : IContentProperty
		{
			/// <summary>
			///     The avatar URL for this user, if any.
			/// </summary>
			public string? AvatarUrl { get; init; }

			/// <summary>
			///     The display name for this user, if any.
			/// </summary>
			public string? Displayname { get; init; }

			/// <summary>
			///     Flag indicating if the room containing this event was created with the intention of being a direct chat.
			/// </summary>
			public bool? IsDirect { get; init; }

			/// <inheritdoc cref="Invite" />
			public Invite? ThirdPartyInvite { get; init; }

			/// <inheritdoc cref="UnsignedData" />
			public UnsignedData? Unsigned { get; init; }

			/// <summary>
			///     The membership state of the user.
			/// </summary>
			public enum MembershipEnum
			{
				Invite,
				Join,
				Knock,
				Leave,
				Ban
			}

			/// <param name="DisplayName"> A name which can be displayed to represent the user instead of their third party identifier</param>
			public record Invite(
				string DisplayName,
				Invite.SignedContent Signed
			)
			{
				/// <summary>
				///     A block of content which has been signed, which servers can use to verify the event. Clients should ignore this.
				/// </summary>
				/// <param name="Mxid"> The invited matrix user ID. Must be equal to the user_id property of the event.</param>
				/// <param name="Signatures">
				///     A single signature from the verifying server, in the format specified by the Signing Events
				///     section of the server-server API.
				/// </param>
				/// <param name="Token"> The token property of the containing third_party_invite object.</param>
				public record SignedContent(
					string Mxid,
					IDictionary<string, IDictionary<string, string>> Signatures,
					string Token
				);
			}

			/// <summary>
			///     Contains optional extra information about the event.
			/// </summary>
			public record UnsignedData
			{
				/// <summary>
				///     A subset of the state of the room at the time of the invite, if ``membership`` is ``invite``. Note that this state
				///     is informational, and SHOULD NOT be trusted; once the client has joined the room, it SHOULD fetch the live state
				///     from the server and discard the invite_room_state. Also, clients must not rely on any particular state being
				///     present here; they SHOULD behave properly (with possibly a degraded but not a broken experience) in the absence of
				///     any particular events here. If they are set on the room, at least the state for ``m.room.avatar``,
				///     ``m.room.canonical_alias``, ``m.room.join_rules``, and ``m.room.name`` SHOULD be included.
				/// </summary>
				public StrippedState[]? InviteRoomState { get; init; }
			}
		}
	}
}