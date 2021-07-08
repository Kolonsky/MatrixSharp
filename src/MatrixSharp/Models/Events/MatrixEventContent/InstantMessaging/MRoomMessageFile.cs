using System.Text.Json.Serialization;
using MatrixSharp.Models.Events.MatrixEventContent.InstantMessaging.Encryption;

namespace MatrixSharp.Models.Events.MatrixEventContent.InstantMessaging
{
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

		/// <inheritdoc cref="FileInfo" />
		[JsonPropertyName("info")]
		public FileInfo? Info { get; set; }

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