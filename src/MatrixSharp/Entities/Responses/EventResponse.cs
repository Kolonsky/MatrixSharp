using System.Text.Json.Serialization;

namespace MatrixSharp.Entities.Responses
{
	/// <summary>
	///     Event response
	/// </summary>
	public class EventResponse
	{
		/// <inheritdoc cref="EventResponse" />
		public EventResponse(string eventId)
		{
			EventId = eventId;
		}

		/// <summary>
		///     A unique identifier for the event.
		/// </summary>
		[JsonPropertyName("event_id")]
		public string EventId { get; }
	}
}