using System.Text.Json.Serialization;

namespace MatrixSharp.Models.Responses
{
	/// <summary>
	///     The login types the homeserver supports
	/// </summary>
	public class LoginTypesResponse
	{
		/// <summary>
		///     The homeserver's supported login types
		/// </summary>
		[JsonPropertyName("flows")]
		public LoginFlow[]? Flows { get; set; }

		/// <summary>
		///     The homeserver's supported login type
		/// </summary>
		public class LoginFlow
		{
			/// <summary>
			///     The login type. This is supplied as the `type` when logging in.
			/// </summary>
			[JsonPropertyName("type")]
			public string? Type { get; set; }
		}
	}
}