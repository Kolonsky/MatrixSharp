namespace MatrixSharp.Api.ClientServer.Definitions
{
	public record SyncFilter
	{
		/// <summary>
		///     List of event fields to include. If this list is absent then all
		///     fields are included. The entries may include '.' characters to indicate sub-fields.
		///     So ['content.body'] will include the 'body' field of the 'content' object. A
		///     literal '.' character in a field name may be escaped using a '\\'. A server may
		///     include more fields than were requested.
		/// </summary>
		public string[]? EventFields { get; init; }

		/// <inheritdoc cref="EventFormatEnum" />
		public EventFormatEnum? EventFormat { get; init; }

		/// <summary>
		///     The presence updates to include.
		/// </summary>
		public EventFilter? Presence { get; init; }

		/// <summary>
		///     The user account data that isn't associated with rooms to include.
		/// </summary>
		public EventFilter? AccountData { get; init; }

		/// <inheritdoc cref="RoomFilter" />
		public RoomFilter? Room { get; init; }

		/// <summary>
		///     The format to use for events. 'client' will return the events in
		///     a format suitable for clients. 'federation' will return the raw event as received
		///     over federation. The default is 'client'.
		/// </summary>
		public enum EventFormatEnum
		{
			Client,
			Federation
		}

		/// <summary>
		///     Filters to be applied to room data.
		/// </summary>
		public record RoomFilter
		{
			/// <summary>
			///     A list of room IDs to exclude. If this list is absent then no rooms
			///     are excluded. A matching room will be excluded even if it is listed in the <see cref="Rooms" />
			///     filter. This filter is applied before the filters in <see cref="Ephemeral" />,
			///     <see cref="State" />, <see cref="Timeline" /> or <see cref="AccountData" />
			/// </summary>
			public string[]? NotRooms { get; init; }

			/// <summary>
			///     A list of room IDs to include. If this list is absent then all rooms
			///     are included. This filter is applied before the filters in <see cref="Ephemeral" />,
			///     <see cref="State" />, <see cref="Timeline" /> or <see cref="AccountData" />
			/// </summary>
			public string[]? Rooms { get; init; }

			/// <summary>
			///     The events that aren't recorded in the room history, e.g. typing
			///     and receipts, to include for rooms.
			/// </summary>
			public RoomEventFilter? Ephemeral { get; init; }

			/// <summary>
			///     Include rooms that the user has left in the sync, default false
			/// </summary>
			public bool? IncludeLeave { get; init; }

			/// <summary>
			///     The state events to include for rooms.
			/// </summary>
			public RoomEventFilter? State { get; init; }

			/// <summary>
			///     The message and state update events to include for rooms.
			/// </summary>
			public RoomEventFilter? Timeline { get; init; }

			/// <summary>
			///     The per user account data to include for rooms.
			/// </summary>
			public RoomEventFilter? AccountData { get; init; }
		}
	}
}