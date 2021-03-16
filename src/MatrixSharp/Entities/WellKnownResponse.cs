using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MatrixSharp.Types;

namespace MatrixSharp.Entities
{
	/// <summary>
	/// Server discovery information.
	/// </summary>
	public struct WellKnownResponse
	{
		/// <inheritdoc cref="HomeserverInformation"/>
		[JsonPropertyName("m.homeserver")]
		public HomeserverInformation Homeserver { get; set; }
		
		/// <inheritdoc cref="IdentityServerInformation"/>
		[JsonPropertyName("m.identity_server")]
		public IdentityServerInformation? IdentityServer { get; set; }
	}
}
