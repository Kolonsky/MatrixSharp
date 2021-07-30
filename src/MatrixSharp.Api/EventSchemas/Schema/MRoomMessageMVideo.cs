using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema.MsgtypeInfos;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     This message represents a single video clip.
	/// </summary>
	[MatrixEventType(TYPE, MSGTYPE)]
	public record RoomVideoMessageEvent : RoomMessageEvent
	{
		private const string MSGTYPE = "m.video";

		/// <inheritdoc cref="RoomVideoMessageEvent" />
		public RoomVideoMessageEvent(ContentProperty content, string eventId, string sender, long originServerTs,
			string roomId) : base(content, eventId, sender, originServerTs, roomId)
		{
		}

		/// <param name="Body">
		///     A description of the video e.g. 'Gangnam style', or some kind of content description for
		///     accessibility e.g. 'video attachment'.
		/// </param>
		public new record ContentProperty(
			string Body
		) : RoomMessageEvent.ContentProperty(Body, MSGTYPE)
		{
			/// <inheritdoc cref="VideoInfo" />
			public VideoInfo? Info { get; init; }

			/// <summary>
			///     Required if the file is unencrypted. The URL to the video clip.
			/// </summary>
			public string? Url { get; init; }

			/// <summary>
			///     Required if the file is encrypted. Information on the encrypted file.
			/// </summary>
			public EncryptedFile? File { get; init; }

			/// <summary>
			///     Metadata about the video clip referred to in ``url``.
			/// </summary>
			public record VideoInfo
			{
				/// <summary>
				///     The duration of the video in milliseconds.
				/// </summary>
				public int? Duration { get; init; }

				/// <summary>
				///     The height of the video in pixels.
				/// </summary>
				public int? H { get; init; }

				/// <summary>
				///     The width of the video in pixels.
				/// </summary>
				public int? W { get; init; }

				/// <summary>
				///     The mimetype of the video e.g. ``video/mp4``.
				/// </summary>
				public string? Mimetype { get; init; }

				/// <summary>
				///     The size of the video in bytes.
				/// </summary>
				public int? Size { get; init; }

				/// <summary>
				///     The URL to an image thumbnail of the video clip.
				///     Only present if the thumbnail unencrypted.
				/// </summary>
				public string? ThumbnailUrl { get; init; }

				/// <summary>
				///     Information on the encrypted thumbnail file.
				///     Only present if the thumbnail is encrypted.
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