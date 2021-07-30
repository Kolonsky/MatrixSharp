using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     A map of which rooms are considered 'direct' rooms for specific users
	///     is kept in  ``account_data`` in an event of type ``m.direct``. The
	///     content of this event is an object where the keys are the user IDs
	///     and values are lists of room ID strings of the 'direct' rooms for
	///     that user ID.
	/// </summary>
	[MatrixEventType("m.direct")]
	public record DirectEvent : Event<DirectEvent.ContentProperty>
	{
		/// <inheritdoc cref="DirectEvent" />
		public DirectEvent(ContentProperty content, string type) : base(content, type)
		{
		}

		public record ContentProperty : IContentProperty
		{
			[JsonExtensionData] public IDictionary<string, JsonElement> UserId { get; init; }
		}
	}
}