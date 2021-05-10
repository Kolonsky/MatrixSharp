using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MatrixSharp.Entities.Events.MatrixEventContent
{
	/// <summary>
	///     The fields in this object will vary depending on the type of event. When interacting with the REST API, this is the
	///     HTTP body.
	/// </summary>
	public class BaseMatrixEventContent
	{
		/// <summary>
		///     The data that is currently can not be parsed.
		/// </summary>
		[JsonExtensionData]
		public IDictionary<string, JsonElement>? ExtensionData { get; set; }
	}
}