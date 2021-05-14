using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MatrixSharp.Entities.Requests
{
	/// <summary>
	///     Request body used to synchronise the client's state with the latest state on the server.
	/// </summary>
	public class SyncRequest
	{
		// TODO: Implement filtering.
		/// <summary>
		///     The ID of a filter created using the filter API or a filter JSON object encoded as a string. The server will detect
		///     whether it is an ID or a JSON object by whether the first character is a "{" open brace. Passing the JSON inline is
		///     best suited to one off requests. Creating a filter using the filter API is recommended for clients that reuse the
		///     same filter multiple times, for example in long poll requests.
		/// </summary>
		[JsonPropertyName("filter")]
		[Obsolete]
		public string? Filter { get; set; }

		/// <summary>
		///     A point in time to continue a sync from.
		/// </summary>
		[JsonPropertyName("since")]
		public string? Since { get; set; }

		/// <summary>
		///     Controls whether to include the full state for all rooms the user is a member of.
		/// </summary>
		/// <remarks>
		///     If this is set to <c>true</c>, then all state events will be returned, even if `since` is non-empty.
		///     The timeline will still be limited by the `since` parameter. In this case, the `timeout`
		///     parameter will be ignored and the query will return immediately, possibly with an empty timeline.
		///     If <c>false</c>, and `since` is non-empty, only state which has changed since the point indicated by
		///     `since` will be returned.
		///     By default, this is <c>false</c>.
		/// </remarks>
		[JsonPropertyName("full_state")]
		public bool? FullState { get; set; }

		/// <summary>
		///     Controls whether the client is automatically marked as online by polling this API. If this parameter is omitted
		///     then the client is automatically marked as <see cref="SetPresenceEnum.Online" /> when it uses this API. Otherwise
		///     if the parameter is set to
		///     <see cref="SetPresenceEnum.Offline" /> then the client is not marked as being online when it uses this API. When
		///     set to <see cref="SetPresenceEnum.Unavailable" />, the
		///     client is marked as being idle.
		/// </summary>
		[JsonPropertyName("set_presence")]
		public SetPresenceEnum? Presence { get; set; }

		/// <summary>
		///     The maximum time to wait, in milliseconds, before returning this request. If no events (or other data) become
		///     available before this time elapses, the server will return a response with empty fields.
		/// </summary>
		/// <remarks>By default, this is `0`, so the server will return immediately even if the response is empty.</remarks>
		[JsonPropertyName("timeout")]
		public int? Timeout { get; set; }

		#region Enums

		/// <summary>
		///     Client status.
		/// </summary>
		public enum SetPresenceEnum
		{
			/// <summary>
			///     Client is online.
			/// </summary>
			[EnumMember(Value = "online")] Online,

			/// <summary>
			///     Client is offline.
			/// </summary>
			[EnumMember(Value = "offline")] Offline,

			/// <summary>
			///     Client is unavailable.
			/// </summary>
			[EnumMember(Value = "unavailable")] Unavailable
		}

		#endregion
	}
}