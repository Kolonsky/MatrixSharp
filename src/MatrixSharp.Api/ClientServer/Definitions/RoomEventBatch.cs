using MatrixSharp.Api.EventSchemas.Schema;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.ClientServer.Definitions
{
	public record RoomEventBatch
	{
		/// <summary>
		///     List of events.
		/// </summary>
		public SyncRoomEvent<ContentPropertyPlaceholder>[]? Events { get; init; }
	}
}