using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema.MsgtypeInfos;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     This message represents a generic file.
	/// </summary>
	[MatrixEventType(TYPE, MSGTYPE)]
	public record RoomFileMessageEvent : RoomMessageEvent
	{
		private const string MSGTYPE = "m.file";

		/// <inheritdoc cref="RoomFileMessageEvent" />
		public RoomFileMessageEvent(ContentProperty content, string eventId, string sender, long originServerTs,
			string roomId) : base(content, eventId, sender, originServerTs, roomId)
		{
		}

		public new record ContentProperty(
			string Body
		) : RoomMessageEvent.ContentProperty(Body, MSGTYPE)
		{
			/// <summary>
			///     The original filename of the uploaded file.
			/// </summary>
			public string? Filename { get; init; }

			/// <inheritdoc cref="FileInfo" />
			public FileInfo? Info { get; init; }

			/// <summary>
			///     Required if the file is unencrypted. The URL to the file.
			/// </summary>
			public string? Url { get; init; }

			/// <summary>
			///     Required if the file is encrypted.
			/// </summary>
			public EncryptedFile? File { get; init; }

			/// <summary>
			///     Information about the file referred to in ``url``.
			/// </summary>
			public record FileInfo
			{
				/// <summary>
				///     The mimetype of the file e.g. ``application/msword``.
				/// </summary>
				public string? Mimetype { get; init; }

				/// <summary>
				///     The size of the file in bytes.
				/// </summary>
				public int? Size { get; init; }

				/// <summary>
				///     The URL to the thumbnail of the file. Only present if the
				///     thumbnail is unencrypted.
				/// </summary>
				public string? ThumbnailUrl { get; init; }

				/// <summary>
				///     Information on the encrypted thumbnail file. Only present if the thumbnail is encrypted.
				/// </summary>
				public EncryptedFile? ThumbnailFile { get; init; }

				/// <summary>
				///     Metadata about the image referred to in ``thumbnail_url``.
				/// </summary>
				public ThumbnailInfo? ThumbnailInfo { get; init; }
			}
		}
	}
}