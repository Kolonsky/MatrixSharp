using System.Text.Json.Serialization;

namespace MatrixSharp.Entities
{
	/// <summary>
	///     The login types the homeserver supports
	/// </summary>
	public class LoginTypesResponse
	{
		/// <summary>
		///     LoginTypesResponse constructor.
		/// </summary>
		public LoginTypesResponse(LoginFlow[]? flows)
		{
			Flows = flows;
		}

		/// <summary>
		///     The homeserver's supported login types
		/// </summary>
		[JsonPropertyName("flows")]
		public LoginFlow[]? Flows { get; }

		/// <summary>
		///     The homeserver's supported login type
		/// </summary>
		public class LoginFlow
		{
			/// <summary>
			///     LoginFlow constructor.
			/// </summary>
			public LoginFlow(string type)
			{
				Type = type;
			}

			/// <summary>
			///     The login type. This is supplied as the `type` when logging in.
			/// </summary>
			[JsonPropertyName("type")]
			public string Type { get; }
		}
	}
}