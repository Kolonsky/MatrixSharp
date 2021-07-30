using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     Represents a server notice for a user.
	/// </summary>
	[MatrixEventType(TYPE, MSGTYPE)]
	public record RoomServerNoticeMessageEvent : RoomMessageEvent
	{
		private const string MSGTYPE = "m.server_notice";

		/// <inheritdoc cref="RoomServerNoticeMessageEvent" />
		public RoomServerNoticeMessageEvent(ContentProperty content, string eventId, string sender, long originServerTs,
			string roomId) : base(content, eventId, sender, originServerTs, roomId)
		{
		}

		/// <param name="Body"> A human-readable description of the notice.</param>
		/// <param name="ServerNoticeType"> The type of notice being represented.</param>
		public new record ContentProperty(
			string Body,
			string ServerNoticeType
		) : RoomMessageEvent.ContentProperty(Body, MSGTYPE)
		{
			/// <summary>
			///     A URI giving a contact method for the server administrator. Required if the
			///     notice type is ``m.server_notice.usage_limit_reached``.
			/// </summary>
			public string? AdminContact { get; init; }

			/// <summary>
			///     The kind of usage limit the server has exceeded. Required if the notice type is
			///     ``m.server_notice.usage_limit_reached``.
			/// </summary>
			public string? LimitType { get; init; }
		}
	}
}