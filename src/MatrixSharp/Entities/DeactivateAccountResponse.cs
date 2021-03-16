using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MatrixSharp.Entities
{
	public struct DeactivateAccountResponse
	{
		/// <summary>
		/// An indicator as to whether or not the homeserver was able to unbind the user's 3PIDs from the identity server(s).
		/// </summary>
		[JsonPropertyName("id_server_unbind_result")]
		public Enum IdServerUnbindResult { get; set; }
	}
}
