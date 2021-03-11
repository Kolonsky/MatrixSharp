using System;
using System.Text.Json.Serialization;

namespace MatrixSharp.Net.Entities
{
	internal abstract class RatelimitedErrorResponse : StandardErrorResponse
	{
		[JsonPropertyName("retry_after_ms")]
		public long RetryAfterMs { get; set; }
	}
}
