using System.Text.Json.Serialization;
using MatrixSharp.Models.Events.MatrixEventContent.InstantMessaging.Encryption;

namespace MatrixSharp.Models.Events.MatrixEventContent.InstantMessaging
{
	/// <summary>
	///     This message represents a single video clip.
	/// </summary>
	public class MRoomMessageVideo : MRoomMessage
	{
		/// <inheritdoc cref="MRoomMessageVideo" />
		public MRoomMessageVideo(string body, MessageTypeEnum messageType) : base(body, messageType)
		{
		}

		/// <inheritdoc cref="VideoInfo" />
		[JsonPropertyName("info")]
		public VideoInfo? Info { get; set; }

		/// <summary>
		///     Required if the file is unencrypted.
		/// </summary>
		[JsonPropertyName("url")]
		public string? Url { get; set; }

		/// <inheritdoc cref="EncryptedFile" />
		/// <remarks> 	Required if the file is encrypted.</remarks>
		[JsonPropertyName("file")]
		public EncryptedFile? File { get; set; }

		#region Models

		/// <summary>
		///     Metadata about the video clip referred to in `url`.
		/// </summary>
		public class VideoInfo
		{
			/// <summary>
			///     The duration of the video in milliseconds.
			/// </summary>
			[JsonPropertyName("duration")]
			public ulong? Duration { get; set; }

			/// <summary>
			///     The height of the video in pixels.
			/// </summary>
			[JsonPropertyName("h")]
			public int? Height { get; set; }

			/// <summary>
			///     The width of the video in pixels.
			/// </summary>
			[JsonPropertyName("w")]
			public int? Width { get; set; }

			/// <summary>
			///     The mimetype of the video e.g.`video/mp4`.
			/// </summary>
			[JsonPropertyName("mimetype")]
			public string? MimeType { get; set; }

			/// <summary>
			///     The size of the video in bytes.
			/// </summary>
			[JsonPropertyName("size")]
			public ulong? Size { get; set; }

			/// <summary>
			///     The URL (typically MXC URI) to an image thumbnail of the video clip. Only present if the thumbnail is unencrypted.
			/// </summary>
			[JsonPropertyName("thumbnail_url")]
			public string? ThumbnailUrl { get; set; }

			/// <inheritdoc cref="EncryptedFile" />
			/// <remarks> Only present if the thumbnail is encrypted.</remarks>
			[JsonPropertyName("thumbnail_file")]
			public EncryptedFile? ThumbnailFile { get; set; }

			/// <inheritdoc cref="MRoomMessage.ThumbnailInfo" />
			[JsonPropertyName("thumbnail_info")]
			public ThumbnailInfo? ThumbnailInfo { get; set; }
		}

		#endregion
	}
}