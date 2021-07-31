using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema.MsgtypeInfos;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     This message represents a single sticker image.
	/// </summary>
	[MatrixEventType(TYPE)]
	public record StickerEvent : RoomEvent<StickerEvent.ContentProperty>
	{
		private const string TYPE = "m.sticker";

		/// <inheritdoc cref="StickerEvent" />
		public StickerEvent(ContentProperty content, string eventId, string sender, long originServerTs, string roomId)
			: base(content, TYPE, eventId, sender, originServerTs, roomId)
		{
		}

		/// <param name="Description">
		///     A textual representation or associated description of the sticker
		///     image. This could be the alt text of the original image, or a message
		///     to accompany and further describe the sticker.
		/// </param>
		/// <param name="Info">
		///     Metadata about the image referred to in ``url`` including a thumbnail
		///     representation.
		/// </param>
		/// <param name="Url"> The URL to the sticker image. This must be a valid ``mxc://`` URI.</param>
		public record ContentProperty(
			string Description,
			ImageInfo Info,
			string Url
		) : IContentProperty;
	}
}