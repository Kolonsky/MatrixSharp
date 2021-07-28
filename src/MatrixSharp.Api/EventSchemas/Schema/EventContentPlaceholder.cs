using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     Placeholder for event content.
	/// </summary>
	public record EventContentPlaceholder : IEventContent
	{
		[JsonExtensionData]
		public IDictionary<string, JsonElement>? ExtensionData { get; init; }
	}

	public interface IEventContent
	{
	}
}