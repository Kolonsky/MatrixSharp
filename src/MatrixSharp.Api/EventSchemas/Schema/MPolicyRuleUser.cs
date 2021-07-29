using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     A moderation policy rule which affects users.
	/// </summary>
	[MatrixEventType("m.policy.rule.user")]
	public record PolicyRuleUserEvent : StateEvent<ModerationPolicyRule>
	{
		/// <inheritdoc cref="PolicyRuleRoomEvent" />
		/// <param name="stateKey">An arbitrary string decided upon by the sender.</param>
		public PolicyRuleUserEvent(ModerationPolicyRule content, string type, string eventId, string sender,
			long originServerTs, string stateKey, string roomId) : base(content, type, eventId, sender, originServerTs,
			stateKey, roomId)
		{
		}
	}
}