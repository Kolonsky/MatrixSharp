namespace MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema
{
	/// <summary>
	///     In addition to the Event fields, Room Events have the following additional
	///     fields.
	/// </summary>
	/// <param name="RoomId">
	///     The ID of the room associated with this event. Will not be present on events
	///     that arrive through ``/sync``, despite being required everywhere else.
	/// </param>
	public record RoomEvent<T>(
		T Content,
		string Type,
		string EventId,
		string Sender,
		long OriginServerTs,
		string RoomId
	) : SyncRoomEvent<T>(Content, Type, EventId, Sender, OriginServerTs) where T : IContentProperty;
}