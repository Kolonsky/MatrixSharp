using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     Informs the client of the list of users currently typing.
	/// </summary>
	[MatrixEventType(TYPE)]
	public record TypingEvent : Event<TypingEvent.ContentProperty>
	{
		private const string TYPE = "m.typing";

		public string RoomId { get; init; }

		/// <inheritdoc cref="TypingEvent" />
		public TypingEvent(ContentProperty content, string roomId) : base(content, TYPE)
		{
			RoomId = roomId;
		}

		/// <param name="UserIds"> The list of user IDs typing in this room, if any.</param>
		public record ContentProperty(
			string[] UserIds
		) : IContentProperty;
	}
}