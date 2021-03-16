using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MatrixSharp.Types
{
	public struct IdentityServerInformation
	{
		/// <summary>
		/// The base URL for the homeserver for client-server connections.
		/// </summary>
		[JsonPropertyName("base_url")]
		public string BaseUrl { get; set; }
	}
}
