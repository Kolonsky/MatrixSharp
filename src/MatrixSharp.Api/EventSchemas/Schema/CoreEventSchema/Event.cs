using System;

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
	) where T : IEventContent;

	/// <summary>
	///     Used to determine the type of event content.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class MatrixEventTypeAttribute : Attribute
	{
		/// <summary>
		///     Event type.
		/// </summary>
		public string Value { get; }

		/// <inheritdoc cref="MatrixEventTypeAttribute" />
		public MatrixEventTypeAttribute(string type)
		{
			Value = type;
		}
	}
}