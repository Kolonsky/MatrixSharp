using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     Informs the client of a user's presence state change.
	/// </summary>
	[MatrixEventType("m.presence")]
	public record PresenceEvent : Event<PresenceEvent.ContentProperty>
	{
		public string Sender { get; init; }

		/// <inheritdoc cref="PresenceEvent" />
		public PresenceEvent(ContentProperty content, string type, string sender) : base(content, type)
		{
			Sender = sender;
		}

		/// <param name="Presence"> The presence state for this user.</param>
		public record ContentProperty(
			ContentProperty.PresenceTypeEnum Presence
		) : IContentProperty
		{
			public enum PresenceTypeEnum
			{
				Online,
				Offline,
				Unavailable
			}

			/// <summary>
			///     The current avatar URL for this user, if any.
			/// </summary>
			public string? AvatarUrl { get; init; }

			/// <summary>
			///     The current display name for this user, if any.
			/// </summary>
			public string? Displayname { get; init; }

			/// <summary>
			///     The last time since this used performed some action, in milliseconds.
			/// </summary>
			public double? LastActiveAgo { get; init; }

			/// <summary>
			///     Whether the user is currently active
			/// </summary>
			public bool? CurrentlyActive { get; init; }

			/// <summary>
			///     An optional description to accompany the presence.
			/// </summary>
			public string? StatusMsg { get; init; }
		}
	}
}