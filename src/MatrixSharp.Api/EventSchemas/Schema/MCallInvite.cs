using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <inheritdoc cref="CallInviteEventContent" />
	[MatrixEventType("m.call.invite")]
	public record CallInviteEvent : RoomEvent<CallInviteEventContent>
	{
		/// <inheritdoc cref="CallInviteEvent" />
		public CallInviteEvent(CallInviteEventContent content, string type, string eventId, string sender,
			long originServerTs, string roomId) : base(content, type, eventId, sender, originServerTs, roomId)
		{
		}
	}

	/// <summary>
	///     This event is sent by the caller when they wish to establish a call.
	/// </summary>
	/// <param name="CallId"> A unique identifier for the call.</param>
	/// <param name="Version"> The version of the VoIP specification this message adheres to. This specification is version 0.</param>
	/// <param name="Lifetime">
	///     The time in milliseconds that the invite is valid for. Once the invite age exceeds this value,
	///     clients should discard it. They should also no longer show the call as awaiting an answer in the UI.
	/// </param>
	public record CallInviteEventContent(
		string CallId,
		Offer Offer,
		int Version,
		int Lifetime
	) : IEventContent;

	/// <summary>
	///     The session description object
	/// </summary>
	/// <param name="Sdp"> The SDP text of the session description.</param>
	public record Offer(
		Offer.TypeEnum Type,
		string Sdp
	)
	{
		/// <summary>
		///     The type of session description.
		/// </summary>
		public enum TypeEnum
		{
			Offer
		}
	}
}