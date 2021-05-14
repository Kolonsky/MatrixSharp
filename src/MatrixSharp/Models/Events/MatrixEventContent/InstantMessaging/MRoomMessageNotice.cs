using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MatrixSharp.Models.Events.MatrixEventContent.InstantMessaging
{
	/// <summary>
	///     The `m.notice` type is primarily intended for responses from automated clients. An `m.notice` message must be
	///     treated
	///     the same way as a regular `m.text` message with two exceptions. Firstly, clients should present `m.notice` messages
	///     to
	///     users in a distinct manner, and secondly, `m.notice` messages must never be automatically responded to. This helps
	///     to
	///     prevent infinite-loop situations where two automated clients continuously exchange messages.
	/// </summary>
	[MatrixEvent("m.room.message", "m.notice")]
	public class MRoomMessageNotice : MRoomMessage
	{
		/// <inheritdoc cref="MRoomMessageNotice" />
		public MRoomMessageNotice(string body, MessageTypeEnum messageType) : base(body, messageType)
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
