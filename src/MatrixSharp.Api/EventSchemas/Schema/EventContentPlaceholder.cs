using System.Collections.Generic;
using System.Text.Json;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     Placeholder for event content.
	/// </summary>
	public record EventContentPlaceholder : IEventContent
	{
		public IDictionary<string, JsonElement>? ExtensionData { get; init; }
	}

	public interface IEventContent
	{
	}
}