using System.Collections.Generic;
using System.Text.Json.Serialization;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     Informs the client of new receipts.
	/// </summary>
	[MatrixEventType(TYPE)]
	public record ReceiptEvent : Event<ReceiptEvent.ContentProperty>
	{
		private const string TYPE = "m.receipt";

		/// <inheritdoc cref="ReceiptEvent" />
		public ReceiptEvent(ContentProperty content) : base(content, TYPE)
		{
		}

		public class ContentProperty : Dictionary<string, ContentProperty.Receipts>, IContentProperty
		{
			/// <summary>
			///     The mapping of event ID to a collection of receipts for this event ID. The event ID is the ID of the event being
			///     acknowledged and *not* an ID for the receipt itself.
			/// </summary>
			public record Receipts
			{
				[JsonPropertyName("m.read")] public Users? Read { get; init; }

				/// <summary>
				///     A collection of users who have sent ``m.read`` receipts for this event.
				/// </summary>
				public class Users : Dictionary<string, Users.Receipt>
				{
					/// <summary>
					///     The mapping of user ID to receipt. The user ID is the entity who sent this receipt.
					/// </summary>
					public record Receipt
					{
						/// <summary>
						///     The timestamp the receipt was sent at.
						/// </summary>
						public double Ts { get; init; }
					}
				}
			}
		}
	}
}