using MatrixSharp.Api.ClientServer.Definitions;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <inheritdoc cref="PushRulesEventContent" />
	[MatrixEventType("m.push_rules")]
	public record PushRulesEvent : Event<PushRulesEventContent>
	{
		/// <inheritdoc cref="PushRulesEvent" />
		public PushRulesEvent(PushRulesEventContent content, string type) : base(content, type)
		{
		}
	}

	/// <summary>
	///     Describes all push rules for this user.
	/// </summary>
	public record PushRulesEventContent : IEventContent
	{
		/// <summary>
		///     The global ruleset
		/// </summary>
		public PushRuleset? Global { get; init; }
	}
}