using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	public record EventContentProperty
	{
		[JsonExtensionData] public IDictionary<string, JsonElement> ExtensionData { get; init; }
	}
}