using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     An invitation to a room issued to a third party identifier, rather than a matrix user ID.
	/// </summary>
	/// <remarks>
	///     Acts as an ``m.room.member`` invite event, where there isn't a target user_id to invite. This event contains a
	///     token and a public key whose private key must be used to sign the token. Any user who can present that signature
	///     may use this invitation to join the target room.
	/// </remarks>
	[MatrixEventType(TYPE)]
	public record RoomThirdPartyInviteEvent : StateEvent<RoomThirdPartyInviteEvent.ContentProperty>
	{
		private const string TYPE = "m.room.third_party_invite";

		/// <inheritdoc cref="RoomThirdPartyInviteEvent" />
		/// <param name="stateKey"> The token, of which a signature must be produced in order to join the room.</param>
		public RoomThirdPartyInviteEvent(ContentProperty content, string eventId, string sender, long originServerTs,
			string stateKey, string roomId) : base(content, TYPE, eventId, sender, originServerTs, stateKey, roomId)
		{
		}

		/// <param name="DisplayName">
		///     A user-readable string which represents the user who has been invited. This should not
		///     contain the user's third party ID, as otherwise when the invite is accepted it would leak the association between
		///     the matrix ID and the third party ID.
		/// </param>
		/// <param name="KeyValidityUrl">
		///     A URL which can be fetched, with querystring public_key=public_key, to validate whether
		///     the key has been revoked. The URL must return a JSON object containing a boolean property named 'valid'.
		/// </param>
		/// <param name="PublicKey">
		///     A base64-encoded ed25519 key with which token must be signed (though a signature from any
		///     entry in public_keys is also sufficient). This exists for backwards compatibility.
		/// </param>
		public record ContentProperty(
			string DisplayName,
			string KeyValidityUrl,
			string PublicKey
		) : IContentProperty
		{
			/// <inheritdoc cref="PublicKeysProp" />
			public PublicKeysProp? PublicKeys { get; init; }

			/// <summary>
			///     Keys with which the token may be signed.
			/// </summary>
			/// <param name="PublicKey"> A base-64 encoded ed25519 key with which token may be signed.</param>
			public record PublicKeysProp(
				string PublicKey
			)
			{
				/// <summary>
				///     An optional URL which can be fetched, with querystring public_key=public_key, to validate whether the key has been
				///     revoked. The URL must return a JSON object containing a boolean property named 'valid'. If this URL is absent, the
				///     key must be considered valid indefinitely.
				/// </summary>
				public string? KeyValidityUrl { get; init; }
			}
		}
	}
}