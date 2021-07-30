using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     The current location of the user's read marker in a room. This event appears in the user's room account data for
	///     the room the marker is applicable for.
	/// </summary>
	[MatrixEventType("m.fully_read")]
	public record FullyReadEvent : Event<FullyReadEvent.ContentProperty>
	{
		/// <summary>
		///     The room ID the read marker applies to.
		/// </summary>
		public string RoomId { get; init; }

		/// <inheritdoc cref="FullyReadEvent" />
		public FullyReadEvent(ContentProperty content, string type, string roomId) : base(content, type)
		{
			RoomId = roomId;
		}

		/// <param name="EventId"> The event the user's read marker is located at in the room.</param>
		public record ContentProperty(
			string EventId
		) : IContentProperty;
	}
}