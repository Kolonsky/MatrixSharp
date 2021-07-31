namespace MatrixSharp.Api.ClientServer.Definitions
{
	public record TimelineBatch : RoomEventBatch
	{
		/// <summary>
		///     True if the number of events returned was limited by the ``limit``
		///     on the filter.
		/// </summary>
		public bool? Limited { get; init; }

		/// <summary>
		///     A token that can be supplied to the ``from`` parameter of the
		///     rooms/{roomId}/messages endpoint.
		/// </summary>
		public string? PrevBatch { get; init; }
	}
}