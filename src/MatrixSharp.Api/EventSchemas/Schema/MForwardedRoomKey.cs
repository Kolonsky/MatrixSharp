using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     This event type is used to forward keys for end-to-end encryption.
	/// </summary>
	[MatrixEventType(TYPE)]
	public record ForwardedRoomKeyEvent : Event<ForwardedRoomKeyEvent.ContentProperty>
	{
		private const string TYPE = "m.forwarded_room_key";

		/// <inheritdoc cref="ForwardedRoomKeyEvent" />
		public ForwardedRoomKeyEvent(ContentProperty content) : base(content, TYPE)
		{
		}

		/// <param name="Algorithm"> The encryption algorithm the key in this event is to be used with.</param>
		/// <param name="RoomId"> The room where the key is used.</param>
		/// <param name="SessionId"> The ID of the session that the key is for.</param>
		/// <param name="SessionKey"> The key to be exchanged.</param>
		/// <param name="SenderKey"> The Curve25519 key of the device which initiated the session originally.</param>
		/// <param name="SenderClaimedEd25519Key">
		///     The Ed25519 key of the device which initiated the session originally.
		///     It is 'claimed' because the receiving device has no way to tell that the
		///     original room_key actually came from a device which owns the private part of
		///     this key unless they have done device verification.
		/// </param>
		/// <param name="ForwardingCurve25519KeyChain">
		///     Chain of Curve25519 keys. It starts out empty, but each time the
		///     key is forwarded to another device, the previous sender in the chain is added
		///     to the end of the list. For example, if the key is forwarded from A to B to
		///     C, this field is empty between A and B, and contains A's Curve25519 key between
		///     B and C.
		/// </param>
		public record ContentProperty(
			string Algorithm,
			string RoomId,
			string SessionId,
			string SessionKey,
			string SenderKey,
			string SenderClaimedEd25519Key,
			string[] ForwardingCurve25519KeyChain
		) : IContentProperty;
	}
}