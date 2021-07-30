using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     A moderation policy rule which affects users.
	/// </summary>
	[MatrixEventType(TYPE)]
	public record PolicyRuleUserEvent : StateEvent<ModerationPolicyRule>
	{
		private const string TYPE = "m.policy.rule.user";

		/// <inheritdoc cref="PolicyRuleRoomEvent" />
		/// <param name="stateKey">An arbitrary string decided upon by the sender.</param>
		public PolicyRuleUserEvent(ModerationPolicyRule content, string eventId, string sender,
			long originServerTs, string stateKey, string roomId) : base(content, TYPE, eventId, sender, originServerTs,
			stateKey, roomId)
		{
		}
	}
}