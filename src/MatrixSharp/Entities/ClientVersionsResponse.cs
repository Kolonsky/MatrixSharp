using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MatrixSharp.Entities
{
	/// <summary>
	///     Versions of the specification supported by the server.
	/// </summary>
	public class ClientVersionsResponse
	{
		/// <summary>
		///     ClientVersionsResponse constructor.
		/// </summary>
		public ClientVersionsResponse(string[] versions, Dictionary<string, bool>? unstableFeatures)
		{
			Versions = versions;
			UnstableFeatures = unstableFeatures;
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
		public Dictionary<string, bool>? UnstableFeatures { get; }
	}
}