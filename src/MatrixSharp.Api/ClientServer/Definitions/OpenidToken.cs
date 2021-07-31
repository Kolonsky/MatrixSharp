namespace MatrixSharp.Api.ClientServer.Definitions
{
	/// <param name="AccessToken">
	///     An access token the consumer may use to verify the identity of
	///     the person who generated the token. This is given to the federation
	///     API ``GET /openid/userinfo`` to verify the user's identity.
	/// </param>
	/// <param name="TokenType"> The string ``Bearer``.</param>
	/// <param name="MatrixServerName">
	///     The homeserver domain the consumer should use when attempting to
	///     verify the user's identity.
	/// </param>
	/// <param name="ExpiresIn">
	///     The number of seconds before this token expires and a new one must
	///     be generated.
	/// </param>
	public record OpenidToken(
		string AccessToken,
		string TokenType,
		string MatrixServerName,
		int ExpiresIn
	);
}