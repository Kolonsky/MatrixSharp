using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     Feedback events are events sent to acknowledge a message in some way. There are two supported acknowledgments:
	///     ``delivered`` (sent when the event has been received) and ``read`` (sent when the event has been observed by the
	///     end-user). The ``target_event_id`` should reference the ``m.room.message`` event being acknowledged.
	/// </summary>
	/// <remarks>
	///     Usage of this event is discouraged in favor of the** `receipts module`_. **Most clients will not recognize
	///     this event.
	/// </remarks>
	[MatrixEventType("m.room.message.feedback")]
	public record RoomMessageFeedbackEvent : RoomEvent<RoomMessageFeedbackEvent.ContentProperty>
	{
		/// <inheritdoc cref="RoomMessageFeedbackEvent" />
		public RoomMessageFeedbackEvent(ContentProperty content, string type, string eventId,
			string sender, long originServerTs, string roomId) : base(content, type, eventId, sender, originServerTs,
			roomId)
		{
		}

		/// <param name="TargetEventId"> The event that this feedback is related to.</param>
		public record ContentProperty(
			string TargetEventId,
			ContentProperty.TypeEnum Type
		) : IContentProperty
		{
			/// <summary>
			///     The type of feedback.
			/// </summary>
			public enum TypeEnum
			{
				Delivered,
				Read
			}
		}
	}
}