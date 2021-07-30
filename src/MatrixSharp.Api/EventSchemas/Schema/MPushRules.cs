using MatrixSharp.Api.ClientServer.Definitions;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     Describes all push rules for this user.
	/// </summary>
	[MatrixEventType("m.push_rules")]
	public record PushRulesEvent : Event<PushRulesEvent.ContentProperty>
	{
		/// <inheritdoc cref="PushRulesEvent" />
		public PushRulesEvent(ContentProperty content, string type) : base(content, type)
		{
		}

		public record ContentProperty : IContentProperty
		{
			/// <summary>
			///     The global ruleset
			/// </summary>
			public PushRuleset? Global { get; init; }
		}
	}
}