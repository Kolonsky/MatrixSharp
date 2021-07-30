using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema.MsgtypeInfos;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     This message represents a single image and an optional thumbnail.
	/// </summary>
	[MatrixEventType(TYPE, MSGTYPE)]
	public record RoomImageMessageEvent : RoomMessageEvent
	{
		private const string MSGTYPE = "m.image";

		/// <inheritdoc cref="RoomImageMessageEvent" />
		public RoomImageMessageEvent(ContentProperty content, string eventId, string sender, long originServerTs,
			string roomId) : base(content, eventId, sender, originServerTs, roomId)
		{
		}

		/// <param name="Body">
		///     A textual representation of the image. This could be the alt text of the image, the filename of the
		///     image, or some kind of content description for accessibility e.g. 'image attachment'.
		/// </param>
		public new record ContentProperty(
			string Body
		) : RoomMessageEvent.ContentProperty(Body, MSGTYPE)
		{
			/// <summary>
			///     Metadata about the image referred to in ``url``.
			/// </summary>
			public ImageInfo? Info { get; init; }

			/// <summary>
			///     Required if the file is unencrypted. The URL to the image.
			/// </summary>
			public string? Url { get; init; }

			/// <summary>
			///     Required if the file is encrypted. Information on the encrypted file.
			/// </summary>
			public EncryptedFile? File { get; init; }
		}
	}
}