using MatrixSharp.Api;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MatrixSharp.Entities
{
	public struct StandardErrorResponse
	{
		/// <summary>
		/// Unique string which can be used to handle an error message.
		/// </summary>
		[JsonPropertyName("errcode")]
		public ErrorCode ErrorCode { get; set; }

		/// <summary>
		/// Human-readable error message, sentence explaining what went wrong.
		/// </summary>
		[JsonPropertyName("error")]
		public string ErrorMessage { get; set; }

		/// <summary>
		/// Additional keys depending on the error
		/// </summary>
		[JsonExtensionData]
		public IDictionary<string, JsonElement>? ExtensionData { get; set; }


	}
}