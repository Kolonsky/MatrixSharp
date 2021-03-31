using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text.Json;
using System.Text.Json.Serialization;
using MatrixSharp.Entities.EventContentTypes;
using MatrixSharp.Entities.EventContentTypes.Modules;

namespace MatrixSharp.Entities.Events
{
	/// <summary>
	///     Base event. The basic set of fields all events must have.
	/// </summary>
	public class Event
	{
		/// <inheritdoc cref="Event" />
		public Event(object content, string type)
		{
			Type = type;

			if (content is not JsonElement)
			{
				Content = content;
				return;
			}

			var jsonEl = (JsonElement)content;
			 
			// TODO: better type matching
			Content = type switch
			{
				"m.room.create" => JsonSerializer.Deserialize<MRoomCreate>(jsonEl.GetRawText())!,
				"m.room.message" => JsonSerializer.Deserialize<MRoomMessage>(jsonEl.GetRawText())!,
				_ => content
			};

		}

		/// <summary>
		///     The fields in this object will vary depending on the type of event. When interacting with the REST API, this is the
		///     HTTP body.
		/// </summary>
		[JsonPropertyName("content")]
		public object Content { get; }

		/// <summary>
		///     The type of event. This SHOULD be namespaced similar to Java package naming conventions e.g.
		///     'com.example.subdomain.event.type'
		/// </summary>
		[JsonPropertyName("type")]
		public string Type { get; }
	}
}