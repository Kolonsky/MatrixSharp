using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MatrixSharp.Models.Responses
{
	/// <summary>
	///     Versions of the specification supported by the server.
	/// </summary>
	public class ClientVersionsResponse
	{
		/// <inheritdoc cref="ClientVersionsResponse" />
		public ClientVersionsResponse(string[] versions)
		{
			Versions = versions;
		}

		/// <summary>
		///     The supported versions.
		/// </summary>
		[JsonPropertyName("versions")]
		public string[] Versions { get; }

		/// <summary>
		///     Experimental features the server supports. Features not listed here, or the lack of this property all together,
		///     indicate that a feature is not supported.
		/// </summary>
		[JsonPropertyName("unstable_features")]
		public Dictionary<string, bool>? UnstableFeatures { get; set; }
	}
}