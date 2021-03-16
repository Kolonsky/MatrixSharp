using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace MatrixSharp.Entities
{
	public struct LoginBody
	{
		/// <summary>
		/// The login type being used. One of: ["m.login.password", "m.login.token"]
		/// </summary>
		/// <exception cref="ArgumentException"></exception>
		[JsonPropertyName("type")]
		public string Type
		{
			get => Type;
			set
			{
				if (value != "m.login.password" || value != "m.login.password")
					throw new ArgumentException("Invalid type", value);
				Type = value;
			}
		}
		
	}

}
