using System;

namespace MatrixSharp.Entities.Events.MatrixEventContent
{
	public class MatrixEventAttribute : Attribute
	{
		public string EventType { get; }
		public string? EventSubtype { get; }

		public MatrixEventAttribute(string type)
		{
			EventType = type;
		}

		public MatrixEventAttribute(string type, string subtype) : this(type)
		{
			EventSubtype = subtype;
		}
	}
}