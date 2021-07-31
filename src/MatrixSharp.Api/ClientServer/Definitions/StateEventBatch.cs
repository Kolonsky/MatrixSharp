using MatrixSharp.Api.EventSchemas.Schema;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.ClientServer.Definitions
{
	public record StateEventBatch
	{
		/// <summary>
		///     List of events.
		/// </summary>
		public SyncStateEvent<ContentPropertyPlaceholder>? Events { get; init; }
	}
}