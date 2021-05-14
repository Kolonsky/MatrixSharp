using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MatrixSharp.Models.Events.MatrixEventContent
{
	/// <summary>
	///     The fields in this object will vary depending on the type of event.
	/// </summary>
	public class BaseMatrixEventContent
	{
		/// <summary>
		///     The data that is currently can not be parsed.
		/// </summary>
		[JsonExtensionData]
		public IDictionary<string, JsonElement>? ExtensionData { get; set; }

		#region Attributes

		/// <summary>
		///     Determines that this class is the content of the event and should be considered when processing the event body.
		/// </summary>
		[AttributeUsage(AttributeTargets.Class)]
		public class MatrixEventAttribute : Attribute
		{
			/// <summary>
			///     The type of event, which is prefixed with `m.`
			/// </summary>
			/// <remarks>
			///     Events are not limited to the types defined in this specification. New or custom event types can be created on
			///     a whim using the Java package naming convention. For example, a `com.example.game.score` event can be sent by
			///     clients and other clients would receive it through Matrix, assuming the client has access to the `com.example`
			///     namespace.
			/// </remarks>
			public string EventType { get; }

			// TODO: It seems like it shouldn't be here.
			/// <summary>
			/// </summary>
			public string? EventSubtype { get; }

			/// <inheritdoc cref="MatrixEventAttribute" />
			public MatrixEventAttribute(string type)
			{
				EventType = type;
			}

			/// <inheritdoc cref="MatrixEventAttribute" />
			public MatrixEventAttribute(string type, string subtype) : this(type)
			{
				EventSubtype = subtype;
			}
		}

		#endregion
	}
}