using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     A moderation policy rule which affects servers.
	/// </summary>
	[MatrixEventType(TYPE)]
	public record PolicyRuleServerEvent : StateEvent<ModerationPolicyRule>
	{
		private const string TYPE = "m.policy.rule.server";

		/// <inheritdoc cref="PolicyRuleRoomEvent" />
		/// <param name="stateKey">An arbitrary string decided upon by the sender.</param>
		public PolicyRuleServerEvent(ModerationPolicyRule content, string eventId, string sender,
			long originServerTs, string stateKey, string roomId) : base(content, TYPE, eventId, sender, originServerTs,
			stateKey, roomId)
		{
		}
	}
}