using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MatrixSharp.Entities.Events.MatrixEventContent.Modules.InstantMessaging
{
	// TODO: Converter for MRoomMessage types.
	/// <summary>
	///     This event is used when sending messages in a room. Messages are not limited to be text. The
	///     `msgtype` key outlines
	///     the type of message, e.g. text, audio, image, video, etc. The `body` key is text and MUST be used with
	///     every kind of
	///     `msgtype` as a fallback mechanism for when a client cannot render a message. This allows clients
	///     to display something
	///     even if it is just plain text.
	/// </summary>
	[MatrixEvent("m.room.message")]
	public class MRoomMessage : BaseMatrixEventContent
	{
		/// <inheritdoc cref="MRoomMessage" />
		public MRoomMessage(string body, MessageTypeEnum messageType)
		{
			Body = body;
			MessageType = messageType;
		}

		/// <summary>
		///     The textual representation of this message.
		/// </summary>
		[JsonPropertyName("body")]
		public string Body { get; }

		/// <inheritdoc cref="MessageTypeEnum" />
		[JsonPropertyName("msgtype")]
		public MessageTypeEnum MessageType { get; }
	}

	/// <summary>
	///     The type of message
	/// </summary>
	public enum MessageTypeEnum
	{
		/// <summary>
		///     This message is the most basic message and is used to represent text.
		/// </summary>
		[EnumMember(Value = "m.text")] Text,

		/// <summary>
		///     This message is similar to m.text except that the sender is 'performing' the action contained in the body key,
		///     similar to /me in IRC. This message should be prefixed by the name of the sender. This message could also be
		///     represented in a different color to distinguish it from regular m.text messages.
		/// </summary>
		[EnumMember(Value = "m.emote")] Emote,

		/// <summary>
		///     The m.notice type is primarily intended for responses from automated clients. An m.notice message must be treated
		///     the same way as a regular m.text message with two exceptions. Firstly, clients should present m.notice messages to
		///     users in a distinct manner, and secondly, m.notice messages must never be automatically responded to. This helps to
		///     prevent infinite-loop situations where two automated clients continuously exchange messages.
		/// </summary>
		[EnumMember(Value = "m.notice")] Notice,

		/// <summary>
		///     This message represents a single image and an optional thumbnail.
		/// </summary>
		[EnumMember(Value = "m.image")] Image,

		/// <summary>
		///     This message represents a generic file.
		/// </summary>
		[EnumMember(Value = "m.file")] File,

		/// <summary>
		///     This message represents a single audio clip.
		/// </summary>
		[EnumMember(Value = "m.audio")] Audio,

		/// <summary>
		///     This message represents a real-world location.
		/// </summary>
		[EnumMember(Value = "m.location")] Location,

		/// <summary>
		///     This message represents a single video clip.
		/// </summary>
		[EnumMember(Value = "m.video")] Video
	}


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

	/// <summary>
	///     This message is similar to `m.text` except that the sender is performing the action contained in the `body` key,
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

	/// <summary>
	///     This message represents a single image and an optional thumbnail.
	/// </summary>
	[MatrixEvent("m.room.message", "m.image")]
	public class MRoomMessageImage : MRoomMessage
	{
		/// <inheritdoc cref="MRoomMessageImage" />
		public MRoomMessageImage(string body, MessageTypeEnum messageType) : base(body, messageType)
		{
		}

		/// <inheritdoc cref="ImageInfo" />
		public ImageInfo? Info { get; set; }

		/// <summary>
		///     Required if the file is unencrypted. The URL (typically MXC URI) to the image.
		/// </summary>
		[JsonPropertyName("url")]
		public string? Url { get; set; }

		// [JsonPropertyName("file")]
		// public EncryptedFile? File{ get; set; }
	}

	/// <summary>
	///     This message represents a generic file.
	/// </summary>
	[MatrixEvent("m.room.message", "m.file")]
	public class MRoomMessageFile : MRoomMessage
	{
		/// <inheritdoc cref="MRoomMessageFile" />
		public MRoomMessageFile(string body, MessageTypeEnum messageType) : base(body, messageType)
		{
		}

		/// <summary>
		///     The original filename of the uploaded file.
		/// </summary>
		[JsonPropertyName("filename")]
		public string? Filename { get; set; }

		/// <inheritdoc cref="InstantMessaging.FileInfo" />
		[JsonPropertyName("info")]
		public FileInfo? FileInfo { get; set; }

		/// <summary>
		///     Required if the file is unencrypted.
		/// </summary>
		[JsonPropertyName("url")]
		public string? Url { get; set; }

		// [JsonPropertyName("file")]
		// public EncryptedFile? File { get; set; }
	}

	// TODO: implement the remaining types


	/// <summary>
	///     Metadata about the image referred to in `url`.
	/// </summary>
	public class ImageInfo
	{
		/// <summary>
		///     The intended display height of the image in pixels. This may differ from the intrinsic dimensions of the image
		///     file.
		/// </summary>
		[JsonPropertyName("h")]
		public int? Height { get; set; }

		/// <summary>
		///     The intended display width of the image in pixels. This may differ from the intrinsic dimensions of the image file.
		/// </summary>
		[JsonPropertyName("w")]
		public int? Width { get; set; }

		/// <summary>
		///     The mimetype of the image.
		/// </summary>
		[JsonPropertyName("mimetype")]
		public string? MimeType { get; set; }

		/// <summary>
		///     Size of the image in bytes.
		/// </summary>
		[JsonPropertyName("size")]
		public ulong? Size { get; set; }

		/// <summary>
		///     The URL (typically MXC URI) to a thumbnail of the image. Only present if the thumbnail is unencrypted.
		/// </summary>
		[JsonPropertyName("thumbnail_url")]
		public string? ThumbnailUrl { get; set; }

		// [JsonPropertyName("thumbnail_file")]
		// public EncryptedFile? ThumbnailFile { get; set; }

		/// <inheritdoc cref="InstantMessaging.ThumbnailInfo" />
		[JsonPropertyName("thumbnail_info")]
		public ThumbnailInfo? ThumbnailInfo { get; set; }
	}

	/// <summary>
	///     Information about the file referred to in `url`.
	/// </summary>
	public class FileInfo
	{
		/// <summary>
		///     The mimetype of the file.
		/// </summary>
		[JsonPropertyName("mimetype")]
		public string? MimeType { get; set; }

		/// <summary>
		///     The size of the file in bytes.
		/// </summary>
		[JsonPropertyName("size")]
		public ulong? Size { get; set; }

		/// <summary>
		///     The URL to the thumbnail of the file. Only present if the thumbnail is unencrypted.
		/// </summary>
		[JsonPropertyName("thumbnail_url")]
		public string? ThumbnailUrl { get; set; }

		// [JsonPropertyName("thumbnail_file")]
		// public EncryptedFile? ThumbnailFile { get; set; }

		/// <inheritdoc cref="InstantMessaging.ThumbnailInfo" />
		[JsonPropertyName("thumbnail_info")]
		public ThumbnailInfo? ThumbnailInfo { get; set; }
	}

	/// <summary>
	///     Metadata about the image referred to in `thumbnail_url`.
	/// </summary>
	public class ThumbnailInfo
	{
		/// <summary>
		///     The intended display height of the image in pixels. This may differ from the intrinsic dimensions of the image
		///     file.
		/// </summary>
		[JsonPropertyName("h")]
		public int? Height { get; set; }

		/// <summary>
		///     The intended display width of the image in pixels. This may differ from the intrinsic dimensions of the image file.
		/// </summary>
		[JsonPropertyName("w")]
		public int? Width { get; set; }

		/// <summary>
		///     The mimetype of the image.
		/// </summary>
		[JsonPropertyName("mimetype")]
		public string? MimeType { get; set; }

		/// <summary>
		///     Size of the image in bytes.
		/// </summary>
		[JsonPropertyName("size")]
		public ulong? Size { get; set; }
	}
}