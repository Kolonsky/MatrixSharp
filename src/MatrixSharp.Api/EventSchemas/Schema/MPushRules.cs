using MatrixSharp.Api.ClientServer.Definitions;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     Describes all push rules for this user.
	/// </summary>
	[MatrixEventType(TYPE)]
	public record PushRulesEvent : Event<PushRulesEvent.ContentProperty>
	{
		private const string TYPE = "m.push_rules";

		/// <inheritdoc cref="PushRulesEvent" />
		public PushRulesEvent(ContentProperty content) : base(content, TYPE)
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