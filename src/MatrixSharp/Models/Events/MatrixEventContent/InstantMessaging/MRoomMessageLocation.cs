using System.Text.Json.Serialization;
using MatrixSharp.Models.Events.MatrixEventContent.InstantMessaging.Encryption;

namespace MatrixSharp.Models.Events.MatrixEventContent.InstantMessaging
{
	/// <summary>
	///     This message represents a real-world location.
	/// </summary>
	public class MRoomMessageLocation : MRoomMessage
	{
		/// <inheritdoc cref="MRoomMessageLocation" />
		public MRoomMessageLocation(string body, MessageTypeEnum messageType, string geoUri) : base(body, messageType)
		{
			GeoUri = geoUri;
		}

		/// <summary>
		///     A geo URI representing this location.
		/// </summary>
		[JsonPropertyName("geo_uri")]
		public string GeoUri { get; }

		/// <inheritdoc cref="LocationInfo" />
		[JsonPropertyName("info")]
		public LocationInfo? Info { get; set; }

		#region Models

		/// <summary>
		///     Information about location.
		/// </summary>
		public class LocationInfo
		{
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