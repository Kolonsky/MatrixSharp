using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     A moderation policy rule which affects servers.
	/// </summary>
	[MatrixEventType("m.policy.rule.server")]
	public record PolicyRuleServerEvent : StateEvent<ModerationPolicyRule>
	{
		/// <inheritdoc cref="PolicyRuleRoomEvent" />
		/// <param name="stateKey">An arbitrary string decided upon by the sender.</param>
		public PolicyRuleServerEvent(ModerationPolicyRule content, string type, string eventId, string sender,
			long originServerTs, string stateKey, string roomId) : base(content, type, eventId, sender, originServerTs,
			stateKey, roomId)
		{
		}
	}
}