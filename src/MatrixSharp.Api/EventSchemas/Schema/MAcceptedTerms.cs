using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     A list of terms URLs the user has previously accepted. Clients SHOULD use this
	///     to avoid presenting the user with terms they have already agreed to.
	/// </summary>
	[MatrixEventType("m.accepted_terms")]
	public record AcceptedTermsEvent : Event<AcceptedTermsEvent.ContentProperty>
	{
		/// <inheritdoc cref="AcceptedTermsEvent" />
		public AcceptedTermsEvent(ContentProperty content, string type) : base(content, type)
		{
		}

		public record ContentProperty : IContentProperty
		{
			/// <summary>
			///     The list of URLs the user has previously accepted. Should be appended to
			///     when the user agrees to new terms.
			/// </summary>
			public string[]? Accepted { get; init; }
		}
	}
}