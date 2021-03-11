namespace MatrixSharp.Net.Api
{
	internal static class Endpoint
	{
		// API Standards
		[MatrixSpec(MatrixSpecAttribute.ApiVersion.R01)]
		public const string VERSIONS = "/_matrix/client/versions";

		// Server Discovery
		public const string WELLKNOWN = "/.well-known/matrix/client";

		// Login

		public const string LOGIN = "/_matrix/client/r0/login";
		public const string LOGOUT = "/_matrix/client/r0/logout";
		public const string LOGOUTALL = "/_matrix/client/r0/logout/all";

		// Account registration and management
		public const string REGISTER = "/_matrix/client/r0/register";
		public const string REGISTEREMAIL = "/_matrix/client/r0/register/email/requestToken";
	}
}