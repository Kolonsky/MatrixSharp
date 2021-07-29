namespace MatrixSharp.Api.ClientServer.Definitions
{
	public record PushRuleset
	{
		public PushRule? Content { get; init; }

		public PushRule? Override { get; init; }

		public PushRule? Room { get; init; }

		public PushRule? Sender { get; init; }

		public PushRule? Underride { get; init; }
	}
}