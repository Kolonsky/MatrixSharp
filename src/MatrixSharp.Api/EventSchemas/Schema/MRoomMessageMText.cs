using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     This message is the most basic message and is used to represent text.
	/// </summary>
	[MatrixEventType(TYPE, MSGTYPE)]
	public record RoomTextMessageEvent : RoomMessageEvent
	{
		private const string MSGTYPE = "m.text";

		/// <inheritdoc cref="RoomTextMessageEvent" />
		public RoomTextMessageEvent(ContentProperty content, string eventId, string sender, long originServerTs,
			string roomId) : base(content, eventId, sender, originServerTs, roomId)
		{
		}

		/// <param name="Body"> The body of the message.</param>
		public new record ContentProperty(
			string Body
		) : RoomMessageEvent.ContentProperty(Body, MSGTYPE)
		{
			/// <summary>
			///     The format used in the ``formatted_body``. Currently only
			///     ``org.matrix.custom.html`` is supported.
			/// </summary>
			public string? Format { get; init; }

			/// <summary>
			///     The formatted version of the ``body``. This is required if ``format``
			///     is specified.
			/// </summary>
			public string? FormattedBody { get; init; }
		}
	}
}