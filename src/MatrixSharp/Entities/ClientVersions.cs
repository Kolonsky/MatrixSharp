using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MatrixSharp.Entities
{
	public class ClientVersions
	{
		/// <summary>
		///     The supported versions.
		/// </summary>
		[JsonPropertyName("versions")]
		public string[] Versions { get; set; }

		/// <summary>
		///     Experimental features the server supports. Features not listed here, or the lack of this property all together,
		///     indicate that a feature is not supported.
		/// </summary>
		[JsonPropertyName("unstable_features")]
		public Dictionary<string, bool> UnstableFeatures { get; set; }
	}
}