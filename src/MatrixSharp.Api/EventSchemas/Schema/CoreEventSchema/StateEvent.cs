namespace MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema
{
	/// <summary>
	///     State Events have the following fields.
	/// </summary>
	public record StateEvent<T>(
		T Content,
		string Type,
		string EventId,
		string Sender,
		long OriginServerTs,
		string StateKey,
		string RoomId
	) : SyncStateEvent<T>(Content, Type, EventId, Sender, OriginServerTs, StateKey) where T : IContentProperty;
}