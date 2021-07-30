using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema
{
	/// <summary>
	///     The basic set of fields all events must have.
	/// </summary>
	/// <param name="Content">
	///     The fields in this object will vary depending on the type of event.
	///     When interacting with the REST API, this is the HTTP body.
	/// </param>
	/// <param name="Type">
	///     The type of event. This SHOULD be namespaced similar to Java package
	///     naming conventions e.g. 'com.example.subdomain.event.type'
	/// </param>
	public record Event<T>(
		T Content,
		string Type
	) where T : IContentProperty
	{
		[JsonExtensionData] public IDictionary<string, JsonElement>? ExtensionData { get; init; }
	}

	/// <summary>
	///     Used to determine the type of event content.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class MatrixEventTypeAttribute : Attribute
	{
		/// <summary>
		///     Event type.
		/// </summary>
		public string Type { get; }

		/// <summary>
		///     Event subtype.
		/// </summary>
		public string Subtype { get; }

		/// <inheritdoc cref="MatrixEventTypeAttribute" />
		public MatrixEventTypeAttribute(string type, string subtype = "")
		{
			Type = type;
			Subtype = subtype;
		}
	}
}