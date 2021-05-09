using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MatrixSharp.Entities.Events.MatrixEventContent
{
	public class BaseMatrixEventContent
	{
		[JsonExtensionData] public IDictionary<string, JsonElement> ExtensionData { get; set; }
	}
}