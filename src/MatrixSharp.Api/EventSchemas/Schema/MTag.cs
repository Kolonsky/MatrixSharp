using System.Collections.Generic;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     Informs the client of tags on a room.
	/// </summary>
	[MatrixEventType(TYPE)]
	public record TagEvent : Event<TagEvent.ContentProperty>
	{
		private const string TYPE = "m.tag";

		/// <inheritdoc cref="TagEvent" />
		public TagEvent(ContentProperty content) : base(content, TYPE)
		{
		}

		public record ContentProperty : IContentProperty
		{
			/// <summary>
			///     The tags on the room and their contents.
			/// </summary>
			public IDictionary<string, Tag>? Tags { get; init; }

			public record Tag
			{
				/// <summary>
				///     A number in a range ``[0,1]`` describing a relative position of the room under the given tag.
				/// </summary>
				public float? Order { get; init; }
			}
		}
	}
}