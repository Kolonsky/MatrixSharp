using System.Text.Json.Serialization;

namespace MatrixSharp.Entities.EventContentTypes
{
	/// <summary>
	///     This is the first event in a room and cannot be changed. It acts as the root of all other events.
	/// </summary>
	public class MRoomCreate
	{
		/// <inheritdoc cref="MRoomCreate" />
		public MRoomCreate(string creator)
		{
			Creator = creator;
		}

		/// <summary>
		///     The user_id of the room creator. This is set by the homeserver.
		/// </summary>
		[JsonPropertyName("creator")]
		public string Creator { get; }

		/// <summary>
		///     Whether users on other servers can join this room. Defaults to true if key does not exist.
		/// </summary>
		[JsonPropertyName("m.federate")]
		public bool? Federate { get; set; }

		/// <inheritdoc cref="PreviousRoom" />
		[JsonPropertyName("predecessor")]
		public PreviousRoom? Predecessor { get; set; }

		/// <summary>
		///     The version of the room. Defaults to "1" if the key does not exist.
		/// </summary>
		[JsonPropertyName("room_version")]
		public string? RoomVersion { get; set; }
	}

	/// <summary>
	///     A reference to the room this room replaces, if the previous room was upgraded.
	/// </summary>
	public class PreviousRoom
	{
		/// <inheritdoc cref="PreviousRoom" />
		public PreviousRoom(string eventId, string roomId)
		{
			EventId = eventId;
			RoomId = roomId;
		}

		/// <summary>
		///     The event ID of the last known event in the old room.
		/// </summary>
		[JsonPropertyName("event_id")]
		public string EventId { get; set; }

		/// <summary>
		///     The ID of the old room.
		/// </summary>
		[JsonPropertyName("room_id")]
		public string RoomId { get; set; }
	}
}