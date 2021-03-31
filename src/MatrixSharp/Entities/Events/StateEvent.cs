using System.Text.Json;
using System.Text.Json.Serialization;

namespace MatrixSharp.Entities.Events
{
	/// <summary>
	///     State event.
	/// </summary>
	public class StateEvent : RoomEvent
	{
		/// <inheritdoc cref="StateEvent" />
		public StateEvent(object content, string type, string eventId, string sender, ulong originServerTs,
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
	}
}