using System.Collections.Generic;
using System.Text.Json.Serialization;
using MatrixSharp.Entities.Events;
using MatrixSharp.Entities.Requests;

namespace MatrixSharp.Entities.Responses
{
	/// <summary>
	///     Latest state on the server.
	/// </summary>
	public class SyncResponse
	{
		/// <inheritdoc cref="SyncResponse" />
		public SyncResponse(string nextBatch)
		{
			NextBatch = nextBatch;
		}

		/// <summary>
		///     The batch token to supply in the `since` param of the next sync request.
		/// </summary>
		public string NextBatch { get; }

		/// <inheritdoc cref="Responses.Rooms" />
		[JsonPropertyName("rooms")]
		public Rooms? Rooms { get; set; }

		/// <inheritdoc cref="Responses.Presence" />
		[JsonPropertyName("presence")]
		public Presence? Presence { get; set; }

		/// <inheritdoc cref="Responses.AccountData" />
		[JsonPropertyName("account_data")]
		public AccountData? AccountData { get; set; }
	}

	#region Rooms

	/// <summary>
	///     Updates to rooms.
	/// </summary>
	public class Rooms
	{
		/// <summary>
		///     The rooms that the user has been invited to, mapped as room ID to room information.
		/// </summary>
		[JsonPropertyName("invite")]
		public Dictionary<string, InvitedRoom>? Invite { get; set; }

		/// <summary>
		///     The rooms that the user has joined, mapped as room ID to room information.
		/// </summary>
		[JsonPropertyName("join")]
		public Dictionary<string, JoinedRoom>? Join { get; set; }

		/// <summary>
		///     The rooms that the user has left or been banned from, mapped as room ID to room information.
		/// </summary>
		[JsonPropertyName("leave")]
		public Dictionary<string, LeftRoom>? Leave { get; set; }
	}

	/// <summary>
	///     Joined room information.
	/// </summary>
	public class JoinedRoom
	{
		/// <inheritdoc cref="Responses.AccountData" />
		[JsonPropertyName("account_data")]
		public AccountData? AccountData { get; set; }

		/// <inheritdoc cref="Responses.Ephemeral" />
		[JsonPropertyName("Ephemeral")]
		public Ephemeral? Ephemeral { get; set; }

		/// <summary>
		///     Updates to the state, between the time indicated by the since parameter, and the start of the timeline (or all
		///     state up to the start of the timeline, if since is not given, or full_state is true).
		/// </summary>
		/// <remarks>
		///     State updates for m.room.member events will be incomplete if lazy_load_members is enabled in the /sync filter,
		///     and only return the member events required to display the senders of the timeline events in this response.
		/// </remarks>
		[JsonPropertyName("state")]
		public State? State { get; set; }

		/// <inheritdoc cref="Responses.RoomSummary" />
		[JsonPropertyName("summary")]
		public RoomSummary? RoomSummary { get; set; }

		/// <inheritdoc cref="Responses.Timeline" />
		[JsonPropertyName("timeline")]
		public Timeline? Timeline { get; set; }

		// TODO: Unread Notification Counts
	}

	/// <summary>
	///     The ephemeral events in the room that aren't recorded in the timeline or state of the room. e.g. typing.
	/// </summary>
	public class Ephemeral
	{
		/// <summary>
		///     List of events.
		/// </summary>
		[JsonPropertyName("events")]
		public Event[]? Events { get; set; }
	}

	/// <summary>
	///     The timeline of messages and state changes in the room.
	/// </summary>
	public class Timeline
	{
		/// <inheritdoc cref="Timeline" />
		public Timeline(bool limited)
		{
			Limited = limited;
		}

		/// <summary>
		///     List of events.
		/// </summary>
		[JsonPropertyName("events")]
		public RoomEvent[]? RoomEvents { get; set; }

		/// <summary>
		///     True if the number of events returned was limited by the limit on the filter.
		/// </summary>
		[JsonPropertyName("limited")]
		public bool Limited { get; }

		/// <summary>
		///     A token that can be supplied to the from parameter of the rooms/{roomId}/messages endpoint.
		/// </summary>
		[JsonPropertyName("prev_batch")]
		public string? PreviousBatch { get; set; }
	}

	/// <summary>
	///     Invited room information.
	/// </summary>
	public class InvitedRoom
	{
		/// <summary>
		///     The state of a room that the user has been invited to. These state events may only have the
		///     <see cref="StrippedState.Sender" />, <see cref="StrippedState.Type" />, <see cref="StrippedState.StateKey" /> and
		///     <see cref="StrippedState.Content" /> keys present. These
		///     events do not replace any state that the client already has for the room, for example if the client has archived
		///     the room. Instead the client should keep two separate copies of the state: the one from the
		///     <see cref="Responses.InviteState" /> and one
		///     from the archived <see cref="Responses.State" />. If the client joins the room then the current state will be given as a
		///     delta against the
		///     archived <see cref="Responses.State" /> not the <see cref="Responses.InviteState" />.
		/// </summary>
		[JsonPropertyName("invite_state")]
		public InviteState? InviteState { get; set; }
	}

	/// <summary>
	///     The state of a room that the user has been invited to.
	/// </summary>
	public class InviteState
	{
		/// <summary>
		///     The StrippedState events that form the invite state.
		/// </summary>
		[JsonPropertyName("events")]
		public StrippedState[]? StrippedStateEvents { get; set; }
	}

	/// <summary>
	///     Additional event data.
	/// </summary>
	public class StrippedState
	{
		/// <inheritdoc cref="StrippedState" />
		public StrippedState(StateEvent.EventContent content, string stateKey, string type, string sender)
		{
			Content = content;
			StateKey = stateKey;
			Type = type;
			Sender = sender;
		}

		/// <summary>
		///     The content for the event.
		/// </summary>
		[JsonPropertyName("content")]
		public StateEvent.EventContent Content { get; }

		/// <summary>
		///     The sender for the event.
		/// </summary>
		[JsonPropertyName("sender")]
		public string Sender { get; }

		/// <summary>
		///     The state_key for the event.
		/// </summary>
		[JsonPropertyName("state_key")]
		public string StateKey { get; }

		/// <summary>
		///     The type for the event.
		/// </summary>
		[JsonPropertyName("type")]
		public string Type { get; }
	}

	/// <summary>
	///     Left room information.
	/// </summary>
	public class LeftRoom
	{
		/// <inheritdoc cref="Responses.State" />
		[JsonPropertyName("state")]
		public State? State { get; set; }

		/// <inheritdoc cref="Responses.Timeline" />
		[JsonPropertyName("timeline")]
		public Timeline? Timeline { get; set; }

		/// <inheritdoc cref="Responses.AccountData" />
		[JsonPropertyName("account_data")]
		public AccountData? AccountData { get; set; }
	}

	/// <summary>
	///     Information about the room which clients may need to correctly render it to users.
	/// </summary>
	public class RoomSummary
	{
		/// <summary>
		///     The users which can be used to generate a room name if the room does not have one. Required if the room's
		///     m.room.name or m.room.canonical_alias state events are unset or empty.
		/// </summary>
		/// <remarks>
		///     This should be the first 5 members of the room, ordered by stream ordering, which are joined or invited. The list
		///     must never include the client's own user ID. When no joined or invited members are available, this should consist
		///     of the banned and left users. More than 5 members may be provided, however less than 5 should only be provided when
		///     there are less than 5 members to represent.
		///     When lazy-loading room members is enabled, the membership events for the heroes MUST be included in the state,
		///     unless they are redundant. When the list of users changes, the server notifies the client by sending a fresh list
		///     of heroes. If there are no changes since the last sync, this field may be omitted.
		/// </remarks>
		[JsonPropertyName("m.heroes")]
		public string[]? Heroes { get; set; }

		/// <summary>
		///     The number of users with membership of invite. If this field has not changed since the last sync, it may be
		///     omitted. Required otherwise.
		/// </summary>
		[JsonPropertyName("m.invited_member_count")]
		public int? InvitedMemberCount { get; set; }

		/// <summary>
		///     The number of users with membership of join, including the client's own user ID. If this field has not changed
		///     since the last sync, it may be omitted. Required otherwise.
		/// </summary>
		[JsonPropertyName("m.joined_member_count")]
		public int? JoinedMemberCount { get; set; }
	}

	/// <summary>
	///     The state updates for the room up to the start of the timeline.
	/// </summary>
	public class State
	{
		/// <summary>
		///     List of events.
		/// </summary>
		[JsonPropertyName("events")]
		public StateEvent[]? SyncStateEvents { get; set; }
	}

	#endregion

	public class Presence
	{
		/// <summary>
		///     List of events.
		/// </summary>
		[JsonPropertyName("events")]
		public Event[]? Events { get; set; }
	}

	/// <summary>
	///     The private data that this user has attached to this room.
	/// </summary>
	public class AccountData
	{
		/// <summary>
		///     List of events.
		/// </summary>
		[JsonPropertyName("events")]
		public Event[]? Events { get; set; }
	}
}