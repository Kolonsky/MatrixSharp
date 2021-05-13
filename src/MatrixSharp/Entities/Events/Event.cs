using System.Text.Json.Serialization;
using MatrixSharp.Entities.Events.MatrixEventContent;
using MatrixSharp.Tools;

namespace MatrixSharp.Entities.Events
{
	/// <summary>
	///     Base event. The basic set of fields all events must have.
	/// </summary>
	[JsonConverter(typeof(ConverterTools.EventConverter<Event>))]
	public class Event
	{
		/// <inheritdoc cref="Event" />
		public Event(BaseMatrixEventContent content, string type)
		{
			Type = type;
			Content = content;
		}

		/// <inheritdoc cref="BaseMatrixEventContent" />
		[JsonPropertyName("content")]
		public BaseMatrixEventContent Content { get; }

		/// <summary>
		///     The type of event. This SHOULD be namespaced similar to Java package naming conventions e.g.
		///     'com.example.subdomain.event.type'
		/// </summary>
		[JsonPropertyName("type")]
		public string Type { get; }
	}
}