using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSharp.Api.ClientServer.Definitions.Errors
{
	/// <summary>
	/// A Matrix-level Error
	/// </summary>
	/// <param name="Errcode"> An error code.</param>
	public record MatrixError(
		string Errcode
	)
	{
		/// <summary>
		/// A human-readable error message.
		/// </summary>
		public string? Error { get; init; }
	}
}
