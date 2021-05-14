namespace MatrixSharp.Api
{
	internal static class Endpoint
	{
		public const string USER = "/_matrix/client/r0/user";

		// API Standards
		[MatrixSpec(MatrixSpecAttribute.ApiVersionEnum.R01)]
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
		public const string REGISTERMSISDN = "/_matrix/client/r0/register/msisdn/requestToken";
		public const string PASSWORD = "/_matrix/client/r0/account/password";
		public const string PASSWORDEMAIL = "/_matrix/client/r0/account/password/email/requestToken";
		public const string PASSWORDMSISDN = "/_matrix/client/r0/account/password/msisdn/requestToken";
		public const string DEACTIVATE = "/_matrix/client/r0/account/deactivate";
		public const string REGISTERAVAILABLE = "/_matrix/client/r0/register/available";

		// Adding Account Administrative Contact Information

		public const string TPID = "/_matrix/client/r0/account/3pid";
		public const string TPIDADD = "/_matrix/client/r0/account/3pid/add";
		public const string TPIDBIND = "/_matrix/client/r0/account/3pid/bind";
		public const string TPIDDELETE = "/_matrix/client/r0/account/3pid/delete";
		public const string TPIDUNBIND = "/_matrix/client/r0/account/3pid/unbind";
		public const string TPIDEMAIL = "/_matrix/client/r0/account/3pid/email/requestToken";
		public const string TPIDMSISDN = "/_matrix/client/r0/account/3pid/msisdn/requestToken";

		// Current account information

		public const string WHOAMI = "/_matrix/client/r0/account/whoami";

		// Capabilities negotiation

		public const string CAPABILITIES = "/_matrix/client/r0/capabilities";

		// Filtering

		public const string USER_FILTER = "/filter";

		// Room events

		public const string SYNC = "/_matrix/client/r0/sync";

		public const string ROOMS = "/_matrix/client/r0/rooms/";
		public const string ROOMS_EVENT = "/event";
		public const string ROOMS_STATE = "/state";
		public const string ROOMS_MEMBERS = "/members";
		public const string ROOMS_JOINEDMEMBERS = "/joined_members";
		public const string ROOMS_MESSAGES = "/messages";

		public const string ROOMS_SEND = "/send";

		public const string ROOMS_REDACT = "/redact";
	}
}