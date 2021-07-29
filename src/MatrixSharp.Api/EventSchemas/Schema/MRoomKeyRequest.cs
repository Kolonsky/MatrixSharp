using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <inheritdoc cref="RoomKeyRequestEventContent" />
	[MatrixEventType("m.room_key_request")]
	public record RoomKeyRequestEvent : Event<RoomKeyRequestEventContent>
	{
		/// <inheritdoc cref="RoomKeyRequestEvent" />
		public RoomKeyRequestEvent(RoomKeyRequestEventContent content, string type) : base(content, type)
		{
		}
	}

	/// <summary>
	///     This event type is used to request keys for end-to-end encryption. It is sent as an
	///     unencrypted `to-device`_ event.
	/// </summary>
	/// <param name="RequestingDeviceId"> ID of the device requesting the key.</param>
	/// <param name="RequestId">
	///     A random string uniquely identifying the request for a key. If the key is
	///     requested multiple times, it should be reused. It should also reused in order
	///     to cancel a request.
	/// </param>
	public record RoomKeyRequestEventContent(
		RoomKeyRequestEventContent.ActionEnum Action,
		string RequestingDeviceId,
		string RequestId
	) : IEventContent
	{
		public enum ActionEnum
		{
			Request,
			RequestCancellation
		}

		/// <inheritdoc cref="RequestedKeyInfo" />
		public RequestedKeyInfo? Body { get; init; }

		/// <summary>
		///     Information about the requested key. Required when ``action`` is
		///     ``request``.
		/// </summary>
		/// <param name="Algorithm">
		///     The encryption algorithm the requested key in this event is to be used
		///     with.
		/// </param>
		/// <param name="RoomId"> The room where the key is used.</param>
		/// <param name="SenderKey"> The Curve25519 key of the device which initiated the session originally.</param>
		/// <param name="SessionId"> The ID of the session that the key is for.</param>
		public record RequestedKeyInfo(
			string Algorithm,
			string RoomId,
			string SenderKey,
			string SessionId
		);
	}
}