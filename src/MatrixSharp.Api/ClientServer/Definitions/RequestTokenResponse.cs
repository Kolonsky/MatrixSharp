namespace MatrixSharp.Api.ClientServer.Definitions
{
	/// <param name="Sid">
	///     The session ID. Session IDs are opaque strings that must consist entirely
	///     of the characters ``[0-9a-zA-Z.=_-]``. Their length must not exceed 255
	///     characters and they must not be empty.
	/// </param>
	public record RequestTokenResponse(
		string Sid
	)
	{
		/// <summary>
		///     An optional field containing a URL where the client must submit the
		///     validation token to, with identical parameters to the Identity Service
		///     API's ``POST /validate/email/submitToken`` endpoint (without the requirement
		///     for an access token). The homeserver must send this token to the user (if
		///     applicable), who should then be prompted to provide it to the client.
		/// </summary>
		/// <remarks>
		///     If this field is not present, the client can assume that verification
		///     will happen without the client's involvement provided the homeserver
		///     advertises this specification version in the ``/versions`` response
		///     (ie: r0.5.0).
		/// </remarks>
		public string? SubmitUrl { get; init; }
	}
}