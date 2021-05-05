using System;

namespace MatrixSharp.Entities.Events
{
	public class MatrixEventAttribute : Attribute
	{
		public string EventType { get; }

		public MatrixEventAttribute(string type)
		{
			EventType = type;
		}
	}
}