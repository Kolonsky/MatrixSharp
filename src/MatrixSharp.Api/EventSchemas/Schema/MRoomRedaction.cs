using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     Events can be redacted by either room or server admins. Redacting an event means that all keys not required by the
	///     protocol are stripped off, allowing admins to remove offensive or illegal content that may have been attached to
	///     any event. This cannot be undone, allowing server owners to physically delete the offending data.  There is also a
	///     concept of a moderator hiding a message event, which can be undone, but cannot be applied to state events. The
	///     event that has been redacted is specified in the ``redacts`` event level key.
	/// </summary>
	[MatrixEventType(TYPE)]
	public record RoomRedactionEvent : RoomEvent<RoomRedactionEvent.ContentProperty>
	{
		private const string TYPE = "m.room.redaction";

		/// <summary>
		///     The event ID that was redacted.
		/// </summary>
		public string Redacts { get; init; }

		/// <inheritdoc cref="RoomRedactionEvent" />
		public RoomRedactionEvent(ContentProperty content, string eventId, string sender, long originServerTs,
			string roomId, string redacts) : base(content, TYPE, eventId, sender, originServerTs, roomId)
		{
			Redacts = redacts;
		}

		public record ContentProperty : IContentProperty
		{
			/// <summary>
			///     The reason for the redaction, if any.
			/// </summary>
			public string? Reason { get; init; }
		}
	}
}