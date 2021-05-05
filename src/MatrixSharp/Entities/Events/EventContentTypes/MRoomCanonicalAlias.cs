using System.Text.Json.Serialization;

namespace MatrixSharp.Entities.Events.EventContentTypes
{
	/// <summary>
	///     This event is used to inform the room about which alias should be considered the canonical one, and which other
	///     aliases point to the room. This could be for display purposes or as suggestion to users which alias to use to
	///     advertise and access the room.
	/// </summary>
	[MatrixEvent("m.room.canonical_alias")]
	public class MRoomCanonicalAlias : BaseEventContentType
	{
		/// <summary>
		///     The canonical alias for the room. If not present, null, or empty the room should be considered to have no canonical
		///     alias.
		/// </summary>
		[JsonPropertyName("alias")]
		public string? Alias { get; set; }

		/// <summary>
		///     Alternative aliases the room advertises. This list can have aliases despite the <see cref="Alias" /> field being
		///     null, empty, or otherwise not present.
		/// </summary>
		[JsonPropertyName("alt_aliases")]
		public string[]? AltAliases { get; set; }
	}
}