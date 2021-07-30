using MatrixSharp.Api.EventSchemas.Schema;

namespace MatrixSharp.Api.EventSchemas
{
	/// <param name="Entity">
	///     The entity affected by this rule. Glob characters ``*`` and ``?`` can be used
	///     to match zero or more and one or more characters respectively.
	/// </param>
	/// <param name="Recommendation"> The suggested action to take. Currently only ``m.ban`` is specified.</param>
	/// <param name="Reason"> The human-readable description for the ``recommendation``.</param>
	public record ModerationPolicyRule(
		string Entity,
		string Recommendation,
		string Reason
	) : IContentProperty;
}