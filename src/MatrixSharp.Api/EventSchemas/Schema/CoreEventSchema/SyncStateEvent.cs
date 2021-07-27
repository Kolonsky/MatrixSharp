using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema
{
	/// <summary>
	///     In addition to the Room Event fields, State Events have the following
	///     additional fields.
	/// </summary>
	/// <param name="StateKey">
	///     A unique key which defines the overwriting semantics for this piece
	///     of room state. This value is often a zero-length string. The presence of this
	///     key makes this event a State Event.
	///     State keys starting with an ``@`` are reserved for referencing user IDs, such
	///     as room members. With the exception of a few events, state events set with a
	///     given user's ID as the state key MUST only be set by that user.
	/// </param>
	public record SyncStateEvent<T>(
		T Content,
		string Type,
		string EventId,
		string Sender,
		long OriginServerTs,
		string StateKey
	) : SyncRoomEvent<T>(Content, Type, EventId, Sender, OriginServerTs) where T : EventContentProperty
	{
		/// <summary>
		///     Optional. The previous ``content`` for this event. If there is no
		///     previous content, this key will be missing.
		/// </summary>
		public EventContent? PrevContent { get; init; }
	}


	// TODO: Not implemented
	public record EventContent
	{
		[JsonExtensionData] public IDictionary<string, JsonElement> ExtensionData { get; init; }
	}
}