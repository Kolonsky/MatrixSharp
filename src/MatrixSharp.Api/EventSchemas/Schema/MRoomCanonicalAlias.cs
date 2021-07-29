using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <inheritdoc cref="CanonicalAliasEventContent" />
	[MatrixEventType("m.room.canonical_alias")]
	public record CanonicalAliasEvent : StateEvent<RoomAvatarEventContent>
	{
		/// <inheritdoc cref="CanonicalAliasEvent" />
		/// <param name="stateKey"> A zero-length string.</param>
		public CanonicalAliasEvent(RoomAvatarEventContent content, string type, string eventId, string sender,
			long originServerTs, string stateKey, string roomId) : base(content, type, eventId, sender, originServerTs,
			stateKey, roomId)
		{
		}
	}

	/// <summary>
	///     This event is used to inform the room about which alias should be
	///     considered the canonical one, and which other aliases point to the room.
	///     This could be for display purposes or as suggestion to users which alias
	///     to use to advertise and access the room.
	/// </summary>
	public record CanonicalAliasEventContent : IEventContent
	{
		/// <summary>
		///     The canonical alias for the room. If not present, null, or empty the
		///     room should be considered to have no canonical alias.
		/// </summary>
		public string? Alias { get; init; }

		/// <summary>
		///     Alternative aliases the room advertises. This list can have aliases
		///     despite the ``alias`` field being null, empty, or otherwise not present.
		/// </summary>
		public string[]? AltAliases { get; init; }
	}
}