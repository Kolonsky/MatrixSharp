using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema.MsgtypeInfos;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     A picture that is associated with the room. This can be displayed alongside the room information.
	/// </summary>
	[MatrixEventType("m.room.avatar")]
	public record RoomAvatarEvent : StateEvent<RoomAvatarEvent.ContentProperty>
	{
		/// <inheritdoc cref="RoomAvatarEvent" />
		/// <param name="stateKey"> A zero-length string.</param>
		public RoomAvatarEvent(ContentProperty content, string type, string eventId, string sender,
			long originServerTs, string stateKey, string roomId) : base(content, type, eventId, sender, originServerTs,
			stateKey, roomId)
		{
		}

		public record ContentProperty(
			string Url) : IContentProperty
		{
			/// <summary>
			///     Metadata about the image referred to in ``url``.
			/// </summary>
			public ImageInfo? Info { get; init; }
		}
	}
}