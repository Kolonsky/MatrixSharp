using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <inheritdoc cref="AcceptedTermsEventContent" />
	[MatrixEventType("m.accepted_terms")]
	public record AcceptedTermsEvent : Event<AcceptedTermsEventContent>
	{
		/// <inheritdoc cref="AcceptedTermsEvent" />
		public AcceptedTermsEvent(AcceptedTermsEventContent content, string type) : base(content, type)
		{
		}
	}

	/// <summary>
	///     A list of terms URLs the user has previously accepted. Clients SHOULD use this
	///     to avoid presenting the user with terms they have already agreed to.
	/// </summary>
	public record AcceptedTermsEventContent : IEventContent
	{
		/// <summary>
		///     The list of URLs the user has previously accepted. Should be appended to
		///     when the user agrees to new terms.
		/// </summary>
		public string[]? Accepted { get; init; }
	}
}