using System;

namespace MatrixSharp.Net.Api
{
	public class MatrixSpecAttribute : Attribute
	{
		public enum ApiVersion
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

		public readonly ApiVersion Version;

		public MatrixSpecAttribute(ApiVersion version)
		{
			Version = version;
		}
	}
}