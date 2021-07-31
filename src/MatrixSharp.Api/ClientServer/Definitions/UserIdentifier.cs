using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MatrixSharp.Api.ClientServer.Definitions
{
	/// <summary>
	/// Identification information for a user
	/// </summary>
	/// <param name="Type"> The type of identification.</param>
	public record UserIdentifier(
		string Type
	);
}
