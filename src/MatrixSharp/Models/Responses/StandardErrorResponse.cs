using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using MatrixSharp.Api;

namespace MatrixSharp.Models.Responses
{
	/// <summary>
	///     Represents any errors that occur at the Matrix API level.
	/// </summary>
	public class StandardErrorResponse
	{
		/// <inheritdoc cref="StandardErrorResponse" />
		public StandardErrorResponse(ErrorCode errorCode, string errorMessage)
		{
			ErrorCode = errorCode;
			ErrorMessage = errorMessage;
		}

		/// <inheritdoc cref="Api.ErrorCode" />
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