using System;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MatrixSharp.Entities.Events
{
	internal class EventConverter<T> : JsonConverter<T> where T : Event
	{
		public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType != JsonTokenType.StartObject)
				throw new JsonException("Expected StartObject token.");

			// Parameters
			BaseEventType content = null;
			string type = null;
			string eventId = null;
			string sender = null;
			ulong originServerTs = default;
			string roomId = null;
			string stateKey = null;

			// Properties
			RoomEvent.UnsignedData? unsigned = null;
			StateEvent.EventContent? previousContent = null;

			Type? contentType = null;

			while (reader.Read())
			{
				if (reader.TokenType == JsonTokenType.EndObject)
				{
					if (stateKey != null)
						return new StateEvent(content, type, eventId, sender, originServerTs, roomId, stateKey) as T;
					if (eventId != null)
						return new RoomEvent(content, type, eventId, sender, originServerTs, roomId) as T;
					if (type != null) return new Event(content, type) as T;

					throw new JsonException("Return statement expected.");
				}

				if (reader.TokenType != JsonTokenType.PropertyName)
					throw new JsonException("Expected PropertyName token.");

				var propName = reader.GetString();
				reader.Read();

				switch (propName)
				{
					case "type":
					{
						type = reader.GetString()!;
						contentType = GetContentTypeFromString(type);
					}
						break;
					case "content":
					{
						if (type == null)
						{
							type = FindContentTypeString(reader);
							contentType = GetContentTypeFromString(type);
						}

						if (contentType == null)
							throw new JsonException("Content type not defined.");

						content =
							(JsonSerializer.Deserialize(ref reader, contentType, options) as BaseEventType)!;
					}
						break;
					case "event_id":
					{
						eventId = reader.GetString()!;
					}
						break;
					case "sender":
					{
						sender = reader.GetString()!;
					}
						break;
					case "origin_server_ts":
					{
						originServerTs = reader.GetUInt64();
					}
						break;
					case "unsigned":
					{
						unsigned =
							JsonSerializer.Deserialize(ref reader, typeof(RoomEvent.UnsignedData), options) as
								RoomEvent.UnsignedData;
					}
						break;
					case "room_id":
					{
						roomId = reader.GetString()!;
					}
						break;
					case "state_key":
					{
						stateKey = reader.GetString()!;
					}
						break;
					case "prev_content":
					{
						previousContent =
							JsonSerializer.Deserialize(ref reader, typeof(StateEvent.EventContent), options) as
								StateEvent.EventContent;
					}
						break;
				}
			}

			throw new JsonException("Expected EndObject token.");
		}

		public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		internal static Type GetContentTypeFromString(string type)
		{
			return Assembly
				       .GetExecutingAssembly()
				       .GetTypes()
				       .FirstOrDefault
				       (t =>
					       (t.BaseType != typeof(BaseEventType) ||
					        t.GetCustomAttribute<MatrixEventAttribute>() != null)
					       && t.GetCustomAttribute<MatrixEventAttribute>()?.EventType == type)
			       ?? typeof(BaseEventType);
		}

		internal static string FindContentTypeString(Utf8JsonReader reader)
		{
			reader.TrySkip();

			var result = string.Empty;
			while (reader.Read())
			{
				if (reader.TokenType == JsonTokenType.EndObject) return result;

				if (reader.TokenType != JsonTokenType.PropertyName)
					throw new JsonException("Expected PropertyName token");

				var propName = reader.GetString();
				reader.Read();

				if (propName == "type") return reader.GetString()!;
			}

			throw new JsonException("Return statement expected");
		}
	}
}