using MatrixSharp.Api.EventSchemas.Schema;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.ClientServer.Definitions
{
	public record EventBatch(
		Event<ContentPropertyPlaceholder>[]? Events
	);
}