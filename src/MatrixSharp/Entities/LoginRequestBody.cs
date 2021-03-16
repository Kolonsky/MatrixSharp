using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace MatrixSharp.Entities
{
	public struct LoginRequestBody
	{
		/// <summary>
		/// The login type being used. One of: ["m.login.password", "m.login.token"]
		/// </summary>
		[JsonPropertyName("type")]
		public string Type { get; set; }
		
	}

}
