using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <inheritdoc cref="CallHangupEventContent" />
	[MatrixEventType("m.call.hangup")]
	public record CallHangupEvent : RoomEvent<CallHangupEventContent>
	{
		/// <inheritdoc cref="CallHangupEvent" />
		public CallHangupEvent(CallHangupEventContent content, string type, string eventId, string sender,
			long originServerTs, string roomId) : base(content, type, eventId, sender, originServerTs, roomId)
		{
		}
	}

	/// <summary>
	///     Sent by either party to signal their termination of the call. This can be sent either once the call has has been
	///     established or before to abort the call.
	/// </summary>
	/// <param name="CallId"> The ID of the call this event relates to.</param>
	/// <param name="Version"> The version of the VoIP specification this message adheres to. This specification is version 0.</param>
	public record CallHangupEventContent(
		string CallId,
		int Version
	) : IEventContent
	{
		/// <inheritdoc cref="ReasonEnum" />
		private ReasonEnum? Reason { get; init; }

		/// <summary>
		///     Optional error reason for the hangup. This should not be provided when the user naturally ends or rejects the call.
		///     When there was an error in the call negotiation, this should be ``ice_failed`` for when ICE negotiation fails or
		///     ``invite_timeout`` for when the other party did not answer in time.
		/// </summary>
		public enum ReasonEnum
		{
			IceFailed,
			InviteTimeout
		}
	}
}