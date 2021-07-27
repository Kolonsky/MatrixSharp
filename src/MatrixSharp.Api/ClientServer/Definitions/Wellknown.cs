using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MatrixSharp.Api.ClientServer.Definitions
{
	/// <summary>
	///     Used by clients to determine the homeserver, identity server, and other
	///     optional components they should be interacting with.
	/// </summary>
	public record DiscoveryInformation(
		[property: JsonPropertyName("m.homeserver")]
		Homeserver Homeserver,
		[property: JsonPropertyName("m.identity_server")]
		IdentityServer? IdentityServer,
		[property: JsonExtensionData] IDictionary<string, JsonElement>? AdditionalProperties
	);

	/// <summary>
	///     Used by clients to discover homeserver information.
	/// </summary>
	/// <param name="BaseUrl"> The base URL for the homeserver for client-server connections.</param>
	public record Homeserver(
		string BaseUrl
	);

	/// <summary>
	///     Used by clients to discover identity server information.
	/// </summary>
	/// <param name="BaseUrl"> The base URL for the identity server for client-server connections.</param>
	public record IdentityServer(
		string BaseUrl
	);
}