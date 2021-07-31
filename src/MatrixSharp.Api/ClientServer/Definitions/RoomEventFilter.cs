namespace MatrixSharp.Api.ClientServer.Definitions
{
	public record RoomEventFilter : EventFilter
	{
		/// <summary>
		///     If ``true``, enables lazy-loading of membership events. Defaults to ``false``.
		/// </summary>
		public bool? LazyLoadMembers { get; init; }

		/// <summary>
		///     If ``true``, sends all membership events for all events, even if they have already
		///     been sent to the client. Does not apply unless <see cref="LazyLoadMembers" /> is ``true``.
		///     Defaults to ``false``.
		/// </summary>
		public bool? IncludeRedundantMembers { get; init; }

		/// <summary>
		///     A list of room IDs to exclude. If this list is absent then no rooms
		///     are excluded. A matching room will be excluded even if it is listed in the <see cref="Rooms" />
		///     filter.
		/// </summary>
		public string[]? NotRooms { get; init; }

		/// <summary>
		///     A list of room IDs to include. If this list is absent then all rooms
		///     are included.
		/// </summary>
		public string[]? Rooms { get; init; }

		/// <summary>
		///     If ``true``, includes only events with a ``url`` key in their content. If
		///     ``false``, excludes those events. If omitted, ``url`` key is not considered for filtering.
		/// </summary>
		public bool? ContainsUrl { get; init; }
	}
}