using System.Text.Json.Serialization;
using MatrixSharp.Net.Api;

namespace MatrixSharp.Net.Entities
{
	public class StandardErrorResponse
	{
		[JsonPropertyName("errcode")] 
		public ErrorCode ErrorCode { get; set; }

		[JsonPropertyName("error")]
		public string ErrorMessage { get; set; }
	}
}
