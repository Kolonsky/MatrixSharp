using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MatrixSharp.Types
{
	/// <summary>
	///  	The homeserver's supported login type
	/// </summary>
	public struct LoginFlow
	{
		/// <summary>
		///  	The login type. This is supplied as the `type` when logging in.
		/// </summary>
		[JsonPropertyName("type")]
		public string? Type { get; set; }
	}
}
