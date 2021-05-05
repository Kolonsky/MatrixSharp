using System.Text.Json.Serialization;

namespace MatrixSharp.Entities.Events.EventContentTypes.Modules
{
	[MatrixEvent("m.room.message")]
	public class MRoomMessage : BaseEventContentType
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