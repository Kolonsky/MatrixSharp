using System.Collections.Generic;
using System.Text.Json;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <inheritdoc cref="IgnoredUserListEventContent" />
	[MatrixEventType("m.ignored_user_list")]
	public record IgnoredUserListEvent : Event<IgnoredUserListEventContent>
	{
		/// <inheritdoc cref="IgnoredUserListEvent" />
		public IgnoredUserListEvent(IgnoredUserListEventContent content, string type) : base(content, type)
		{
		}
	}

	/// <summary>
	///     A map of users which are considered ignored is kept in ``account_data``
	///     in an event type of ``m.ignored_user_list``.
	/// </summary>
	/// <param name="IgnoredUsers"> The map of users to ignore</param>
	public record IgnoredUserListEventContent(
		IDictionary<string, JsonElement> IgnoredUsers
	) : IEventContent;
}