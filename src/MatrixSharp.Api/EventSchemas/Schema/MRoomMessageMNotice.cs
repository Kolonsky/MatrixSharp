using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     The ``m.notice`` type is primarily intended for responses from automated clients. An ``m.notice`` message must be
	///     treated the same way as a regular ``m.text`` message with two exceptions. Firstly, clients should present
	///     ``m.notice`` messages to users in a distinct manner, and secondly, ``m.notice`` messages must never be
	///     automatically responded to. This helps to prevent infinite-loop situations where two automated clients continuously
	///     exchange messages.
	/// </summary>
	[MatrixEventType(TYPE, MSGTYPE)]
	public record RoomNoticeMessageEvent : RoomMessageEvent
	{
		private const string MSGTYPE = "m.notice";

		/// <inheritdoc cref="RoomNoticeMessageEvent" />
		public RoomNoticeMessageEvent(ContentProperty content, string eventId, string sender, long originServerTs,
			string roomId) : base(content, eventId, sender, originServerTs, roomId)
		{
		}

		/// <param name="Body"> The notice text to send.</param>
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