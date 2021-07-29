using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema.MsgtypeInfos;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <inheritdoc cref="RoomAvatarEventContent" />
	[MatrixEventType("m.room.avatar")]
	public record RoomAvatarEvent : StateEvent<RoomAvatarEventContent>
	{
		/// <inheritdoc cref="RoomAvatarEvent" />
		/// <param name="stateKey"> A zero-length string.</param>
		public RoomAvatarEvent(RoomAvatarEventContent content, string type, string eventId, string sender,
			long originServerTs, string stateKey, string roomId) : base(content, type, eventId, sender, originServerTs,
			stateKey, roomId)
		{
		}
	}

	/// <summary>
	///     A picture that is associated with the room. This can be displayed alongside the room information.
	/// </summary>
	public record RoomAvatarEventContent(
		string Url) : IEventContent
	{
		/// <summary>
		///     Metadata about the image referred to in ``url``.
		/// </summary>
		public ImageInfo? Info { get; init; }
	}
}