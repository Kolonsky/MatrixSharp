using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema.MsgtypeInfos;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     This message represents a real-world location.
	/// </summary>
	[MatrixEventType(TYPE, MSGTYPE)]
	public record RoomLocationMessageEvent : RoomMessageEvent
	{
		private const string MSGTYPE = "m.location";

		/// <inheritdoc cref="RoomLocationMessageEvent" />
		public RoomLocationMessageEvent(ContentProperty content, string eventId, string sender, long originServerTs,
			string roomId) : base(content, eventId, sender, originServerTs, roomId)
		{
		}

		/// <param name="Body">
		///     A description of the location e.g. 'Big Ben, London, UK', or some kind of content description for
		///     accessibility e.g. 'location attachment'.
		/// </param>
		/// <param name="GeoUri"> A geo URI representing this location.</param>
		public new record ContentProperty(
			string Body,
			string GeoUri
		) : RoomMessageEvent.ContentProperty(Body, MSGTYPE)
		{
			public LocationInfo? Info { get; init; }

			public record LocationInfo
			{
				/// <summary>
				///     The URL to the thumbnail of the file. Only present if the thumbnail is unencrypted.
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