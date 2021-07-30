using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     This event is sent by the callee when they wish to answer the call.
	/// </summary>
	[MatrixEventType("m.call.answer")]
	public record CallAnswerEvent : RoomEvent<CallAnswerEvent.ContentProperty>
	{
		/// <inheritdoc cref="CallAnswerEvent" />
		public CallAnswerEvent(ContentProperty content, string type, string eventId, string sender,
			long originServerTs, string roomId) : base(content, type, eventId, sender, originServerTs, roomId)
		{
		}

		/// <param name="CallId"> The ID of the call this event relates to.</param>
		public record ContentProperty(
			string CallId,
			Answer Answer,
			double Version
		) : IContentProperty;


		/// <summary>
		///     The session description object
		/// </summary>
		/// <param name="Sdp"> The SDP text of the session description.</param>
		public record Answer(
			Answer.TypeEnum Type,
			string Sdp
		)
		{
			/// <summary>
			///     The type of session description.
			/// </summary>
			public enum TypeEnum
			{
				Answer
			}
		}
	}
}