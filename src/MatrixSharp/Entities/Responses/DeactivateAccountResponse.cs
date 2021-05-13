using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MatrixSharp.Entities.Responses
{
	/// <summary>
	///     Information about account deactivation.
	/// </summary>
	public class DeactivateAccountResponse
	{
		/// <inheritdoc cref="IdServerUnbindResultEnum" />
		/// <remarks>
		///     This must be `success` if the homeserver has no identifiers to unbind
		///     for the user.
		/// </remarks>
		[JsonPropertyName("id_server_unbind_result")]
		public IdServerUnbindResultEnum IdServerUnbindResult { get; set; }
	}

	/// <summary>
	///     An indicator as to whether or not the homeserver was able to unbind the user's 3PIDs from the identity server(s).
	/// </summary>
	public enum IdServerUnbindResultEnum
	{
		/// <summary>
		///     Indicates that all identifiers have been unbound from the identity server.
		/// </summary>
		[EnumMember(Value = "success")] Success,

		/// <summary>
		///     Indicates that one or more identifiers failed to unbind due to the identity server refusing the request or the
		///     homeserver being unable to determine an identity server to unbind from.
		/// </summary>
		[EnumMember(Value = "no-support")] NoSupport
	}
}