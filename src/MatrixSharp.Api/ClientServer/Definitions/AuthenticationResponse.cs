using System.Collections.Generic;
using System.Text.Json;

namespace MatrixSharp.Api.ClientServer.Definitions
{
	/// <summary>
	///     Used by servers to indicate that additional authentication information is required
	/// </summary>
	/// <param name="Flows"> A list of the login flows supported by the server for this API.</param>
	/// <param name="Params">
	///     Contains any information that the client will need to know in order to
	///     use a given type of authentication. For each login type presented,
	///     that type may be present as a key in this dictionary. For example, the
	///     public part of an OAuth client ID could be given here.
	/// </param>
	/// <param name="Session">
	///     This is a session identifier that the client must pass back to the home
	///     server, if one is provided, in subsequent attempts to authenticate in the
	///     same API call.
	/// </param>
	/// <param name="Completed"> A list of the stages the client has completed successfully</param>
	public record AuthenticationResponse(
		FlowInformation[] Flows,
		IDictionary<string, JsonElement>? Params,
		string? Session,
		string[]? Completed
	);

	/// <summary>
	///     The login type of each of the stages required to complete authentication flow
	/// </summary>
	public record FlowInformation(
		string[] Stages
	);
}