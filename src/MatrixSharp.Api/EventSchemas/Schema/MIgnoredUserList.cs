using System.Collections.Generic;
using System.Text.Json;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     A map of users which are considered ignored is kept in ``account_data``
	///     in an event type of ``m.ignored_user_list``.
	/// </summary>
	[MatrixEventType(TYPE)]
	public record IgnoredUserListEvent : Event<IgnoredUserListEvent.ContentProperty>
	{
		private const string TYPE = "m.ignored_user_list";

		/// <inheritdoc cref="IgnoredUserListEvent" />
		public IgnoredUserListEvent(ContentProperty content) : base(content, TYPE)
		{
		}

		/// <param name="IgnoredUsers"> The map of users to ignore</param>
		public record ContentProperty(
			IDictionary<string, JsonElement> IgnoredUsers
		) : IContentProperty;
	}
}