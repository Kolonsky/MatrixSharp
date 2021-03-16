using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MatrixSharp.Entities
{
	public struct LoginTypes
	{
		/// <summary>
		/// The homeserver's supported login types
		/// </summary>
		[JsonPropertyName("flows")]
		public LoginFlow[]? Flows { get; set; } 
	}


	/// <summary>
	/// Homeserver's login type.
	/// </summary>
	public struct LoginFlow
	{
		/// <summary>
		///  	The login type. This is supplied as the <see cref="LoginFlow"/> when logging in.
		/// </summary>
		[JsonPropertyName("type")]
		public string? Type { get; set; }
	}
}
