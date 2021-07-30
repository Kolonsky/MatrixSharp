using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     This event is sent by the caller when they wish to establish a call.
	/// </summary>
	[MatrixEventType(TYPE)]
	public record CallInviteEvent : RoomEvent<CallInviteEvent.ContentProperty>
	{
		private const string TYPE = "m.call.invite";

		/// <inheritdoc cref="CallInviteEvent" />
		public CallInviteEvent(ContentProperty content, string eventId, string sender, long originServerTs,
			string roomId) : base(content, TYPE, eventId, sender, originServerTs, roomId)
		{
		}

		/// <param name="CallId"> A unique identifier for the call.</param>
		/// <param name="Version"> The version of the VoIP specification this message adheres to. This specification is version 0.</param>
		/// <param name="Lifetime">
		///     The time in milliseconds that the invite is valid for. Once the invite age exceeds this value,
		///     clients should discard it. They should also no longer show the call as awaiting an answer in the UI.
		/// </param>
		public record ContentProperty(
			string CallId,
			Offer Offer,
			int Version,
			int Lifetime
		) : IContentProperty;

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
}