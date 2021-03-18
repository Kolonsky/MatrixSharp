using System;
using System.Text.Json.Serialization;

namespace MatrixSharp.Entities
{
	/// <summary>
	/// </summary>
	public class DeactivateAccountResponse
	{
		/// <summary>
		///     An indicator as to whether or not the homeserver was able to unbind the user's 3PIDs from the identity server(s).
		/// </summary>
		[JsonPropertyName("id_server_unbind_result")]
		public Enum IdServerUnbindResult { get; set; }
	}
}