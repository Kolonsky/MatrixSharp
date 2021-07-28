using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <inheritdoc cref="FullyReadEventContent" />
	[MatrixEventType("m.fully_read")]
	public record FullyReadEvent : Event<FullyReadEventContent>
	{
		/// <summary>
		///     The room ID the read marker applies to.
		/// </summary>
		public string RoomId { get; init; }

		/// <inheritdoc cref="FullyReadEvent" />
		public FullyReadEvent(FullyReadEventContent content, string type, string roomId) : base(content, type)
		{
			RoomId = roomId;
		}
	}

	/// <summary>
	///     The current location of the user's read marker in a room. This event appears in the user's room account data for
	///     the room the marker is applicable for.
	/// </summary>
	/// <param name="EventId"> The event the user's read marker is located at in the room.</param>
	public record FullyReadEventContent(
		string EventId
	) : IEventContent;
}