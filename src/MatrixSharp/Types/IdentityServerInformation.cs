using System.Text.Json.Serialization;

namespace MatrixSharp.Types
{
	/// <summary>
	///     Used by clients to discover identity server information.
	/// </summary>
	public struct IdentityServerInformation
	{
		/// <summary>
		///     The base URL for the homeserver for client-server connections.
		/// </summary>
		[JsonPropertyName("base_url")]
		public string BaseUrl { get; set; }
	}
}