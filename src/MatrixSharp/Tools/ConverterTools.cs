using System;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using MatrixSharp.Entities.Events;
using MatrixSharp.Entities.Events.MatrixEventContent;
using MatrixSharp.Entities.Events.MatrixEventContent.Modules.InstantMessaging;

namespace MatrixSharp.Tools
{
	internal static class ConverterTools
	{
		private static Type DefineByType(string type, Type fallbackType)
		{
			return Assembly
				       .GetExecutingAssembly()
				       .GetTypes()
				       .FirstOrDefault
				       (t =>
					       (t.BaseType != fallbackType ||
					        t.GetCustomAttribute<MatrixEventAttribute>() != null)
					       && t.GetCustomAttribute<MatrixEventAttribute>()?.EventType == type)
			       ?? fallbackType;
		}

		private static Type DefineBySubtype(string type, string subtype, Type fallbackType)
		{
			return Assembly
				       .GetExecutingAssembly()
				       .GetTypes()
				       .FirstOrDefault
				       (t =>
					       t.BaseType != fallbackType
					       && t.GetCustomAttribute<MatrixEventAttribute>() != null
					       && t.GetCustomAttribute<MatrixEventAttribute>()!.EventSubtype != null
					       && t.GetCustomAttribute<MatrixEventAttribute>()!.EventType == type
					       && t.GetCustomAttribute<MatrixEventAttribute>()!.EventSubtype == subtype)
			       ?? fallbackType;
		}

		private static string FindTypeString(Utf8JsonReader reader, string prop)
		{
			while (reader.Read())
			{
				if (reader.TokenType == JsonTokenType.EndObject)
					throw new JsonException("Return statement expected.");

				if (reader.TokenType != JsonTokenType.PropertyName)
					throw new JsonException("Expected PropertyName token");

				var propName = reader.GetString();
				reader.Read();

				if (propName == prop) return reader.GetString()!;
			}

			throw new JsonException("Return statement expected");
		}

		internal class EventConverter<T> : JsonConverter<T> where T : Event
		{
			public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
			{
				if (reader.TokenType != JsonTokenType.StartObject)
					throw new JsonException("Expected StartObject token.");

				// Parameters
				BaseMatrixEventContent content = null;
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
							return new StateEvent(content, type, eventId, sender, originServerTs, roomId,
								stateKey) as T;
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
							contentType = DefineByType(type, typeof(BaseMatrixEventContent));
						}
							break;
						case "content":
						{
							if (type == null)
							{
								var snapshot = reader;
								snapshot.TrySkip();
								type = FindTypeString(snapshot, "type");
								contentType = DefineByType(type, typeof(BaseMatrixEventContent));
							}

							if (contentType == null)
								throw new JsonException("Content type not defined.");

							content =
								(JsonSerializer.Deserialize(ref reader, contentType, options) as BaseMatrixEventContent)
								!;
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
		}

		// TODO: Not working as expected. Rewrite.
		[Obsolete]
		internal class RoomMessageConverter : JsonConverter<MRoomMessage>
		{
			public override MRoomMessage Read(ref Utf8JsonReader reader, Type typeToConvert,
				JsonSerializerOptions options)
			{
				if (reader.TokenType != JsonTokenType.StartObject)
					throw new JsonException("Expected StartObject token.");

				var type = typeof(MRoomMessage).GetCustomAttribute<MatrixEventAttribute>()!.EventType;

				var snapshot = reader;
				var subtype = FindTypeString(snapshot, "msgtype");

				var contentType = DefineBySubtype(type, subtype, typeof(MRoomMessage));

				if (contentType != typeof(MRoomMessage))
					return (JsonSerializer.Deserialize(ref reader, contentType, options) as MRoomMessage)!;


				string body = null;
				MessageTypeEnum msgtype = default;

				while (reader.Read())
				{
					if (reader.TokenType == JsonTokenType.EndObject) return new MRoomMessage(body, msgtype);

					if (reader.TokenType != JsonTokenType.PropertyName)
						throw new JsonException("Expected PropertyName token.");

					var propName = reader.GetString();
					reader.Read();

					switch (propName)
					{
						case "msgtype":
						{
							// Ignore
						}
							break;
						case "body":
						{
							body = reader.GetString()!;
						}
							break;
						default:
						{
							// TODO: Better handling
							// Ignore
						}
							break;
					}
				}

				throw new JsonException("Expected EndObject token.");
			}

			public override void Write(Utf8JsonWriter writer, MRoomMessage value, JsonSerializerOptions options)
			{
				throw new NotImplementedException();
			}
		}
	}
}