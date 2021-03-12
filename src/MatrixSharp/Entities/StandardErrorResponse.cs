using System.Text.Json.Serialization;
using MatrixSharp.Api;

namespace MatrixSharp.Entities
{
	public class StandardErrorResponse
	{
		[JsonPropertyName("errcode")] public ErrorCode ErrorCode { get; set; }

		[JsonPropertyName("error")] public string ErrorMessage { get; set; }
	}
}