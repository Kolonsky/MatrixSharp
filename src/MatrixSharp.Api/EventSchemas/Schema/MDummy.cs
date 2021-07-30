using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     This event type is used to indicate new Olm sessions for end-to-end encryption.
	///     Typically it is encrypted as an ``m.room.encrypted`` event, then sent as a `to-device`_
	///     event.
	///     The event does not have any content associated with it. The sending client is expected
	///     to send a key share request shortly after this message, causing the receiving client to
	///     process this ``m.dummy`` event as the most recent event and using the keyshare request
	///     to set up the session. The keyshare request and ``m.dummy`` combination should result
	///     in the original sending client receiving keys over the newly established session.
	/// </summary>
	[MatrixEventType("m.dummy")]
	public record DummyEvent : Event<ContentPropertyPlaceholder>
	{
		/// <inheritdoc cref="DummyEvent" />
		public DummyEvent(ContentPropertyPlaceholder content, string type) : base(content, type)
		{
		}
	}
}