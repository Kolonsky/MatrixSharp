namespace MatrixSharp.Api.ClientServer.Definitions
{
	public record EventFilter
	{
		/// <summary>
		///     The maximum number of events to return.
		/// </summary>
		public int? Limit { get; init; }

		/// <summary>
		///     A list of sender IDs to exclude. If this list is absent then no senders
		///     are excluded. A matching sender will be excluded even if it is listed in the
		///     <see cref="Senders" /> filter.
		/// </summary>
		public string[]? NotSenders { get; init; }

		/// <summary>
		///     A list of event types to exclude. If this list is absent then no
		///     event types are excluded. A matching type will be excluded even if it is listed
		///     in the <see cref="Types" /> filter. A '*' can be used as a wildcard to match any sequence
		///     of characters.
		/// </summary>
		public string[]? NotTypes { get; init; }

		/// <summary>
		///     A list of senders IDs to include. If this list is absent then all
		///     senders are included.
		/// </summary>
		public string[]? Senders { get; init; }

		/// <summary>
		///     A list of event types to include. If this list is absent then all
		///     event types are included. A ``'*'`` can be used as a wildcard to match any sequence
		///     of characters.
		/// </summary>
		public string[]? Types { get; init; }
	}
}