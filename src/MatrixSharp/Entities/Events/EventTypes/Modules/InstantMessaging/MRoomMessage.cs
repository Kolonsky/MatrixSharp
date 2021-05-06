using System.Text.Json.Serialization;

namespace MatrixSharp.Entities.Events.EventTypes.Modules.InstantMessaging
{
	[MatrixEvent("m.room.message")]
	public class MRoomMessage : BaseEventType
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