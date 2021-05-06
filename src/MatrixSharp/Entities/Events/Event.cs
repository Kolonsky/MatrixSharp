using System.Text.Json.Serialization;

namespace MatrixSharp.Entities.Events
{
	/// <summary>
	///     Base event. The basic set of fields all events must have.
	/// </summary>
	[JsonConverter(typeof(EventConverter<Event>))]
	public class Event
	{
		/// <inheritdoc cref="Event" />
		public Event(BaseEventType content, string type)
		{
			Type = type;
			Content = content;
		}

		/// <summary>
		///     The fields in this object will vary depending on the type of event. When interacting with the REST API, this is the
		///     HTTP body.
		/// </summary>
		[JsonPropertyName("content")]
		public BaseEventType Content { get; }

		/// <summary>
		///     The type of event. This SHOULD be namespaced similar to Java package naming conventions e.g.
		///     'com.example.subdomain.event.type'
		/// </summary>
		[JsonPropertyName("type")]
		public string Type { get; }
	}
}