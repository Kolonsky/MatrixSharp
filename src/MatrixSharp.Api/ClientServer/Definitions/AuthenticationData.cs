using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MatrixSharp.Api.ClientServer.Definitions
{
	/// <summary>
	///     Used by clients to submit authentication information to the interactive-authentication API
	/// </summary>
	/// <param name="Type"> The login type that the client is attempting to complete.</param>
	/// <param name="Session"> The value of the session key given by the homeserver.</param>
	/// <param name="AdditionalProperties"> Keys dependent on the login type</param>
	public record AuthData(
		string Type,
		string? Session,
		[property: JsonExtensionData] IDictionary<string, JsonElement>? AdditionalProperties
	);
}