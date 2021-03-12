using System.Text.Json.Serialization;

namespace MatrixSharp.Entities
{
	public class RatelimitedErrorResponse : StandardErrorResponse
	{
		[JsonPropertyName("retry_after_ms")] public long RetryAfterMs { get; set; }
	}
}