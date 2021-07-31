namespace MatrixSharp.Api.ClientServer.Definitions
{
	public record Event
	{
		/// <summary>
		///     The ID of this event, if applicable.
		/// </summary>
		public string? EventId { get; init; }

		/// <summary>
		///     The content of this event. The fields in this object will vary depending
		///     on the type of event.
		/// </summary>
		public object? Content { get; init; }

		/// <summary>
		///     Timestamp in milliseconds on originating homeserver when this event
		///     was sent.
		/// </summary>
		public long? OriginServerTs { get; init; }

		/// <summary>
		///     The MXID of the user who sent this event.
		/// </summary>
		public string? Sender { get; init; }

		/// <summary>
		///     Optional. This key will only be present for state events. A unique
		///     key which defines the overwriting semantics for this piece of room state.
		/// </summary>
		public string? StateKey { get; init; }

		/// <summary>
		///     The type of event.
		/// </summary>
		public string? Type { get; init; }

		/// <inheritdoc cref="UnsignedProp" />
		public UnsignedProp? Unsigned { get; init; }

		/// <summary>
		///     Information about this event which was not sent by the originating
		///     homeserver
		/// </summary>
		public record UnsignedProp
		{
			/// <summary>
			///     Time in milliseconds since the event was sent.
			/// </summary>
			public long? Age { get; init; }

			/// <summary>
			///     Optional. The previous ``content`` for this state. This will
			///     be present only for state events appearing in the ``timeline``. If this
			///     is not a state event, or there is no previous content, this key will be
			///     missing.
			/// </summary>
			public object? PrevContent { get; init; }

			/// <summary>
			///     Optional. The transaction ID set when this message was sent.
			///     This key will only be present for message events sent by the device calling
			///     this API.
			/// </summary>
			public string? TransactionId { get; init; }

			/// <summary>
			///     Optional. The event that redacted this event, if any.
			/// </summary>
			public object? RedactedBecause { get; init; }
		}
	}
}