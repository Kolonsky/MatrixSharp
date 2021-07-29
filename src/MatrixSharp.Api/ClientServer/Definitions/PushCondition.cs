namespace MatrixSharp.Api.ClientServer.Definitions
{
	/// <param name="Kind"> The kind of condition to apply.</param>
	public record PushCondition(
		string Kind
	)
	{
		/// <summary>
		///     Required for ``event_match`` conditions. The dot-separated field of the
		///     event to match.
		///     Required for ``sender_notification_permission`` conditions. The field in
		///     the power level event the user needs a minimum power level for. Fields
		///     must be specified under the ``notifications`` property in the power level
		///     event's ``content``.
		/// </summary>
		public string? Key { get; init; }

		/// <summary>
		///     Required for ``event_match`` conditions. The glob-style pattern to
		///     match against. Patterns with no special glob characters should be
		///     treated as having asterisks prepended and appended when testing the
		///     condition.
		/// </summary>
		public string? Pattern { get; init; }

		/// <summary>
		///     Required for ``room_member_count`` conditions. A decimal integer
		///     optionally prefixed by one of, ==, &lt;, &gt;, &gt;= or &lt;=. A prefix of &lt; matches
		///     rooms where the member count is strictly less than the given number and
		///     so forth. If no prefix is present, this parameter defaults to ==.
		/// </summary>
		public string? Is { get; init; }
	}
}