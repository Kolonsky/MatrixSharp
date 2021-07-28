using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <inheritdoc cref="IdentityServerEventContent" />
	[MatrixEventType("m.identity_server")]
	public record IdentityServerEvent : Event<IdentityServerEventContent>
	{
		/// <inheritdoc cref="IdentityServerEvent" />
		public IdentityServerEvent(IdentityServerEventContent content, string type) : base(content, type)
		{
		}
	}

	/// <summary>
	///     Persists the user's preferred identity server, or preference to not use
	///     an identity server at all, in the user's account data.
	/// </summary>
	public record IdentityServerEventContent : IEventContent
	{
		/// <summary>
		///     The URL of the identity server the user prefers to use, or ``null``
		///     if the user does not want to use an identity server. This value is
		///     similar in structure to the ``base_url`` for identity servers in the
		///     ``.well-known/matrix/client`` schema.
		/// </summary>
		public string? BaseUrl { get; init; }
	}
}