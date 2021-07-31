using System;

namespace MatrixSharp.Api.ClientServer.Definitions
{
	public record RequestEmailValidation(
		string ClientSecret,
		string Email,
		int SendAttempt
	) : Identity.Definitions.RequestEmailValidation(ClientSecret, Email, SendAttempt)
	{
		/// <summary>
		///     The hostname of the identity server to communicate with. May optionally
		///     include a port. This parameter is ignored when the homeserver handles
		///     3PID verification.
		/// </summary>
		/// <remarks>
		///     This parameter is deprecated with a plan to be removed in a future specification
		///     version for ``/account/password`` and ``/register`` requests.
		/// </remarks>
		[Obsolete]
		public string? IdServer { get; init; }

		/// <summary>
		///     An access token previously registered with the identity server. Servers
		///     can treat this as optional to distinguish between r0.5-compatible clients
		///     and this specification version.
		/// </summary>
		/// <remarks> Required if an ``id_server`` is supplied.</remarks>
		public string? IdAccessToken { get; init; }
	}
}