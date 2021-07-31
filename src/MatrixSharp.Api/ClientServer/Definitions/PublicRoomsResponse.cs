namespace MatrixSharp.Api.ClientServer.Definitions
{
	/// <summary>
	///     A list of the rooms on the server.
	/// </summary>
	/// <param name="Chunks"> A paginated chunk of public rooms.</param>
	public record PublicRoomsResponse(
		PublicRoomsResponse.PublicRoomsChunk[] Chunks
	)
	{
		/// <summary>
		///     A pagination token for the response. The absence of this token
		///     means there are no more results to fetch and the client should
		///     stop paginating.
		/// </summary>
		public string? NextBatch { get; init; }

		/// <summary>
		///     A pagination token that allows fetching previous results. The
		///     absence of this token means there are no results before this
		///     batch, i.e. this is the first batch.
		/// </summary>
		public string? PrevBatch { get; init; }

		/// <summary>
		///     An estimate on the total number of public rooms, if the
		///     server has an estimate.
		/// </summary>
		public int? TotalRoomCountEstimate { get; init; }

		/// <param name="RoomId"> The ID of the room.</param>
		/// <param name="NumJoinedMembers"> The number of members joined to the room.</param>
		/// <param name="WorldReadable"> Whether the room may be viewed by guest users without joining.</param>
		/// <param name="GuestCanJoin">
		///     Whether guest users may join the room and participate in it.
		///     If they can, they will be subject to ordinary power level
		///     rules like any other user.
		/// </param>
		public record PublicRoomsChunk(
			string RoomId,
			int NumJoinedMembers,
			bool WorldReadable,
			bool GuestCanJoin
		)
		{
			/// <summary>
			///     Aliases of the room. May be empty.
			/// </summary>
			public string[]? Aliases { get; init; }

			/// <summary>
			///     The canonical alias of the room, if any.
			/// </summary>
			public string? CanonicalAlias { get; init; }

			/// <summary>
			///     The name of the room, if any.
			/// </summary>
			public string? Name { get; init; }

			/// <summary>
			///     The topic of the room, if any.
			/// </summary>
			public string? Topic { get; init; }

			/// <summary>
			///     The URL for the room's avatar, if one is set.
			/// </summary>
			public string? AvatarUrl { get; init; }
		}
	}
}