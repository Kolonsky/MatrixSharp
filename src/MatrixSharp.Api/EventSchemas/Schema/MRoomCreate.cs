using System.Text.Json.Serialization;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     This is the first event in a room and cannot be changed. It acts as the root of all other events.
	/// </summary>
	[MatrixEventType(TYPE)]
	public record RoomCreateEvent : StateEvent<RoomCreateEvent.ContentProperty>
	{
		private const string TYPE = "m.room.create";

		/// <inheritdoc cref="RoomCreateEvent" />
		public RoomCreateEvent(ContentProperty content, string eventId, string sender, long originServerTs,
			string stateKey, string roomId) : base(content, TYPE, eventId, sender, originServerTs, stateKey, roomId)
		{
		}

		/// <param name="Creator"> The ``user_id`` of the room creator. This is set by the homeserver.</param>
		public record ContentProperty(
			string Creator
		) : IContentProperty
		{
			/// <summary>
			///     Whether users on other servers can join this room. Defaults to ``true`` if key does not exist.
			/// </summary>
			/// <remarks>
			///     The value of this property will be true if the response body does not contain this key.
			/// </remarks>
			[JsonPropertyName("m.federate")]
			public bool CanFederate { get; init; } = true;

			/// <summary>
			///     The version of the room. Defaults to ``"1"`` if the key does not exist.
			/// </summary>
			public string? RoomVersion { get; init; }

			/// <inheritdoc cref="PreviousRoom" />
			public PreviousRoom? Predecessor { get; init; }

			/// <summary>
			///     A reference to the room this room replaces, if the previous room was upgraded.
			/// </summary>
			/// <param name="RoomId"> The ID of the old room.</param>
			/// <param name="EventId"> The event ID of the last known event in the old room.</param>
			public record PreviousRoom(
				string RoomId,
				string EventId
			);
		}
	}
}