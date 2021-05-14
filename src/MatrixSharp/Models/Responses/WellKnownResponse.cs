using System.Text.Json.Serialization;

namespace MatrixSharp.Models.Responses
{
	/// <summary>
	///     Server discovery information.
	/// </summary>
	public class WellKnownResponse
	{
		/// <inheritdoc cref="WellKnownResponse" />
		public WellKnownResponse(HomeserverInformation homeserver, IdentityServerInformation? identityServer)
		{
			Homeserver = homeserver;
			IdentityServer = identityServer;
		}

		/// <inheritdoc cref="HomeserverInformation" />
		[JsonPropertyName("m.homeserver")]
		public HomeserverInformation Homeserver { get; }

		/// <inheritdoc cref="IdentityServerInformation" />
		[JsonPropertyName("m.identity_server")]
		public IdentityServerInformation? IdentityServer { get; }

		#region Types

		/// <summary>
		///     Used by clients to discover homeserver information.
		/// </summary>
		public class HomeserverInformation
		{
			/// <inheritdoc cref="HomeserverInformation" />
			public HomeserverInformation(string baseUrl)
			{
				BaseUrl = baseUrl;
			}

			/// <summary>
			///     The base URL for the homeserver for client-server connections.
			/// </summary>
			[JsonPropertyName("base_url")]
			public string BaseUrl { get; }
		}

		/// <summary>
		///     Used by clients to discover identity server information.
		/// </summary>
		public class IdentityServerInformation
		{
			/// <inheritdoc cref="IdentityServerInformation" />
			public IdentityServerInformation(string baseUrl)
			{
				BaseUrl = baseUrl;
			}

			/// <summary>
			///     The base URL for the homeserver for client-server connections.
			/// </summary>
			[JsonPropertyName("base_url")]
			public string BaseUrl { get; }
		}

		#endregion
	}
}