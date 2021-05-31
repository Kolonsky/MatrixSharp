using System.Text.Json.Serialization;

namespace MatrixSharp.Models.Events.MatrixEventContent.InstantMessaging
{
	/// <summary>
	///     This message is the most basic message and is used to represent text.
	/// </summary>
	[MatrixEvent("m.room.message", "m.text")]
	public class MRoomMessageText : MRoomMessage
	{
		/// <inheritdoc cref="MRoomMessageText" />
		public MRoomMessageText(string body, MessageTypeEnum messageType) : base(body, messageType)
		{
		}

		/// <summary>
		///     The format used in the formatted_body.
		/// </summary>
		[JsonPropertyName("format")]
		public string? Format { get; set; }

		/// <summary>
		///     The formatted version of the body. This is required if format is specified.
		/// </summary>
		[JsonPropertyName("formatted_body")]
		public string? FormattedBody { get; set; }
	}
}