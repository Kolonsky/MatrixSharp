using System.Text.Json.Serialization;

namespace MatrixSharp.Entities.Events
{
	/// <summary>
	/// </summary>
	public class Invite
	{
		/// <inheritdoc cref="Invite" />
		public Invite(string displayName, Signed signed)
		{
			DisplayName = displayName;
			Signed = signed;
		}

		/// <summary>
		///     A name which can be displayed to represent the user instead of their third party identifier
		/// </summary>
		[JsonPropertyName("display_name")]
		public string DisplayName { get; }

		/// <inheritdoc cref="Events.Signed" />
		[JsonPropertyName("signed")]
		public Signed Signed { get; }
	}

	/// <summary>
	///     A block of content which has been signed, which servers can use to verify the event. Clients should ignore this.
	/// </summary>
	public class Signed
	{
		/// <inheritdoc cref="Signed" />
		public Signed(string mxid, Signatures signatures, string token)
		{
			Mxid = mxid;
			Signatures = signatures;
			Token = token;
		}

		/// <summary>
		///     The invited matrix user ID. Must be equal to the user_id property of the event.
		/// </summary>
		[JsonPropertyName("mxid")]
		public string Mxid { get; }

		/// <inheritdoc cref="Events.Signatures" />
		[JsonPropertyName("signatures")]
		public Signatures Signatures { get; }

		/// <summary>
		///     The token property of the containing third_party_invite object.
		/// </summary>
		[JsonPropertyName("token")]
		public string Token { get; }
	}

	/// <summary>
	///     A single signature from the verifying server, in the format specified by the Signing Events section of the
	///     server-server API.
	/// </summary>
	public class Signatures
	{
	}
}