using System.Text.Json.Serialization;

namespace MatrixSharp.Entities
{
	public struct LoginResponse
	{
		/// <summary>
		///     The fully-qualified Matrix ID that has been registered.
		/// </summary>
		[JsonPropertyName("user_id")]
		public string? UserId { get; set; }

		/// <summary>
		///     An access token for the account. This access token can then be used to authorize other requests.
		/// </summary>
		[JsonPropertyName("access_token")]
		public string? AccessToken { get; set; }

		/// <summary>
		///     The server_name of the homeserver on which the account has been registered.
		/// </summary>
		/// <remarks></remarks>
		[JsonPropertyName("home_server")]
		public string? HomeServer { get; set; }

		/// <summary>
		///     ID of the logged-in device. Will be the same as the corresponding parameter in the request, if one was specified.
		/// </summary>
		[JsonPropertyName("device_id")]
		public string? DeviceId { get; set; }

		/// <summary>
		///     Optional client configuration provided by the server. If present, clients SHOULD use the provided object to
		///     reconfigure themselves, optionally validating the URLs within. This object takes the same form as the one returned
		///     from .well-known autodiscovery.
		/// </summary>
		[JsonPropertyName("well_known")]
		public WellKnownResponse? WellKnown { get; set; }
	}
}