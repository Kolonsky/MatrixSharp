using System;

namespace MatrixSharp.Api
{
	internal class MatrixSpecAttribute : Attribute
	{
		public readonly ApiVersionEnum ApiVersion;

		public MatrixSpecAttribute(ApiVersionEnum apiVersion)
		{
			ApiVersion = apiVersion;
		}

		#region Enums

		public enum ApiVersionEnum
		{
			Unknown,
			Unstable,
			R01,
			R02,
			R03,
			R04,
			R05,
			R06
		}

		#endregion
	}
}