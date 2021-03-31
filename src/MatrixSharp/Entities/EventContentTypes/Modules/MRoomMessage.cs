using System.Text.Json.Serialization;

namespace MatrixSharp.Entities.EventContentTypes.Modules
{
	public class MRoomMessage
	{
		public MRoomMessage(string body, string messageType)
		{
			Body = body;
			MessageType = messageType;
		}

		[JsonPropertyName("body")] public string Body { get; }

		[JsonPropertyName("msgtype")] public string MessageType { get; }
	}
}