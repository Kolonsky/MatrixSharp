using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MatrixSharp.Entities.Events
{
	internal class EventConverter : JsonConverter<Event>
	{
		public override Event Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType != JsonTokenType.StartObject) throw new JsonException();

			string type = "";
			Type? contentType = null;
			Event mEvent = null!;

			while (reader.Read())
			{
				if (reader.TokenType == JsonTokenType.EndObject)
				{
					return mEvent ?? throw new JsonException();
				}

				if (reader.TokenType != JsonTokenType.PropertyName) throw new JsonException();

				var propertyName = reader.GetString();

				switch (propertyName)
				{
					case "type":
					{
						reader.Read();
						type = reader.GetString() ?? "";

						contentType = Assembly
							.GetExecutingAssembly()
							.GetTypes()
							.FirstOrDefault(t => (
								                     t.BaseType != typeof(BaseEventContentType)
								                     || t.GetCustomAttribute<MatrixEventAttribute>() != null)
							                     && t.GetCustomAttribute<MatrixEventAttribute>()?.EventType == type);
						if (contentType == null) contentType = typeof(BaseEventContentType);
					}
						break;
					case "content":
					{
						if (contentType == null)
							// TODO: Handling situations where the type parameter does not come first
							throw new JsonException("Wrong parameters positioning in json. Type should be first.");

						reader.Read();
						var content =
							JsonSerializer.Deserialize(ref reader, contentType, options) as BaseEventContentType;

						mEvent = new Event(content, type);
					}
						break;

					default:
					{
						reader.TrySkip();
					}
						break;
				}
			}

			throw new JsonException();
		}

		public override void Write(Utf8JsonWriter writer, Event value, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}
	}
}