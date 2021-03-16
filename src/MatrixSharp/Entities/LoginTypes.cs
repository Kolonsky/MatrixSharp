using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MatrixSharp.Types;

namespace MatrixSharp.Entities
{
	/// <summary>
	/// The login types the homeserver supports
	/// </summary>
	public struct LoginTypes
	{
		/// <summary>
		/// The homeserver's supported login types
		/// </summary>
		[JsonPropertyName("flows")]
		public LoginFlow[]? Flows { get; set; }
	}
}
