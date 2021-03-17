using System.Text.Json.Serialization;
using MatrixSharp.Types;

namespace MatrixSharp.Entities
{
	/// <summary>
	///     Server discovery information.
	/// </summary>
	public struct WellKnownResponse
	{
		/// <inheritdoc cref="HomeserverInformation" />
		[JsonPropertyName("m.homeserver")]
		public HomeserverInformation Homeserver { get; set; }

		/// <inheritdoc cref="IdentityServerInformation" />
		[JsonPropertyName("m.identity_server")]
		public IdentityServerInformation? IdentityServer { get; set; }
	}
}