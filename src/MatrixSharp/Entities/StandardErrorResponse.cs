using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using MatrixSharp.Api;

namespace MatrixSharp.Entities
{
	/// <summary>
	///     Represents any errors that occur at the Matrix API level.
	/// </summary>
	public class StandardErrorResponse
	{
		/// <summary>
		///     StandardErrorResponse constructor.
		/// </summary>
		public StandardErrorResponse(ErrorCode errorCode, string errorMessage,
			IDictionary<string, JsonElement>? extensionData)
		{
			ErrorCode = errorCode;
			ErrorMessage = errorMessage;
			ExtensionData = extensionData;
		}

		/// <summary>
		///     Unique string which can be used to handle an error message.
		/// </summary>
		[JsonPropertyName("errcode")]
		public ErrorCode ErrorCode { get; }

		/// <summary>
		///     Human-readable error message, sentence explaining what went wrong.
		/// </summary>
		[JsonPropertyName("error")]
		public string ErrorMessage { get; }

		/// <summary>
		///     Additional keys depending on the error
		/// </summary>
		[JsonExtensionData]
		public IDictionary<string, JsonElement>? ExtensionData { get; set; }
	}
}