using System.Text.Json.Serialization;

namespace MatrixSharp.Models.Events.MatrixEventContent.InstantMessaging
{
	/// <summary>
	///     This message is similar to `m.text` except that the sender is ‘performing’ the action contained in the `body` key,
	///     similar to */me* in IRC. This message should be prefixed by the name of the sender. This message could also be
	///     represented in a different color to distinguish it from regular `m.text` messages.
	/// </summary>
	[MatrixEvent("m.room.message", "m.emote")]
	public class MRoomMessageEmote : MRoomMessage
	{
		/// <inheritdoc cref="MRoomMessageEmote" />
		public MRoomMessageEmote(string body, MessageTypeEnum messageType) : base(body, messageType)
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