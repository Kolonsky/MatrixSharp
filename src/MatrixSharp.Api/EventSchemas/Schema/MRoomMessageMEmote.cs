using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     This message is similar to ``m.text`` except that the sender is 'performing' the action contained in the ``body``
	///     key, similar to ``/me`` in IRC. This message should be prefixed by the name of the sender. This message could also
	///     be represented in a different colour to distinguish it from regular ``m.text`` messages.
	/// </summary>
	[MatrixEventType(TYPE, MSGTYPE)]
	public record RoomEmoteMessageEvent : RoomMessageEvent
	{
		private const string MSGTYPE = "m.emote";

		/// <inheritdoc cref="RoomEmoteMessageEvent" />
		public RoomEmoteMessageEvent(ContentProperty content, string eventId, string sender, long originServerTs,
			string roomId) : base(content, eventId, sender, originServerTs, roomId)
		{
		}

		/// <param name="Body"> The emote action to perform.</param>
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