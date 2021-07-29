using System.Text.Json;

namespace MatrixSharp.Api.ClientServer.Definitions
{
	/// <param name="Actions"> The actions to perform when this rule is matched.</param>
	/// <param name="Default"> Whether this is a default rule, or has been set explicitly.</param>
	/// <param name="Enabled"> Whether the push rule is enabled or not.</param>
	/// <param name="RuleId"> The ID of this rule.</param>
	public record PushRule(
		JsonElement Actions,
		bool Default,
		bool Enabled,
		string RuleId
	)
	{
		/// <summary>
		///     The conditions that must hold true for an event in order for a rule to be
		///     applied to an event. A rule with no conditions always matches. Only
		///     applicable to ``underride`` and ``override`` rules.
		/// </summary>
		public PushCondition[]? Conditions { get; init; }

		/// <summary>
		///     The glob-style pattern to match against.  Only applicable to ``content``
		///     rules.
		/// </summary>
		public string? Pattern { get; init; }
	}
}