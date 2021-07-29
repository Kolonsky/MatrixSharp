using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     A stripped down state event, with only the ``type``, ``state_key``,
	///     ``sender``, and ``content`` keys.
	/// </summary>
	/// <param name="Content"> The ``content`` for the event.</param>
	/// <param name="StateKey"> The ``state_key`` for the event.</param>
	/// <param name="Type"> The ``type`` for the event.</param>
	/// <param name="Sender"> The ``sender`` for the event.</param>
	public record StrippedState(
		EventContent Content,
		string StateKey,
		string Type,
		string Sender
	);
}