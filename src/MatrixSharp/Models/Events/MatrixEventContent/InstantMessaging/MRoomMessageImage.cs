using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MatrixSharp.Models.Events.MatrixEventContent.InstantMessaging
{
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

		// TODO: file

		#region Models

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

			// TODO: thumbnail_file

			#region Models

			/// <inheritdoc cref="MRoomMessage.ThumbnailInfo" />
			[JsonPropertyName("thumbnail_info")]
			public ThumbnailInfo? ThumbnailInfo { get; set; }

			#endregion
		}

		#endregion
	}
}
