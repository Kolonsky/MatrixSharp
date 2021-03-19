namespace MatrixSharp.Api
{
	/// <summary>
	///     Unique constants that can be used to handle the error message.
	/// </summary>
	public enum ErrorCode
	{
		/// <summary>
		///     An unknown error has occurred.
		/// </summary>
		M_UNKNOWN,

		/// <summary>
		///     Forbidden access, e.g. joining a room without permission, failed login.
		/// </summary>
		M_FORBIDDEN,

		/// <summary>
		///     The access token specified was not recognised.
		/// </summary>
		M_UNKNOWN_TOKEN,

		/// <summary>
		/// No access token was specified for the request.
		/// </summary>
		M_MISSING_TOKEN,

		/// <summary>
		///     Request contained valid JSON, but it was malformed.
		/// </summary>
		M_BAD_JSON,

		/// <summary>
		///     Request did not contain valid JSON.
		/// </summary>
		M_NOT_JSON,

		/// <summary>
		///     No resource was found for this request.
		/// </summary>
		M_NOT_FOUND,

		/// <summary>
		///     Too many requests have been sent in a short period of time.
		/// </summary>
		M_LIMIT_EXCEEDED,

		/// <summary>
		///     The server did not understand the request.
		/// </summary>
		M_UNRECOGNIZED,

		/// <summary>
		///     The request was not correctly authorized. Usually due to login failures.
		/// </summary>
		M_UNAUTHORIZED,

		/// <summary>
		///     The user ID associated with the request has been deactivated.
		/// </summary>
		M_USER_DEACTIVATED,

		/// <summary>
		///     Encountered when trying to register a user ID which has been taken.
		/// </summary>
		M_USER_IN_USE,

		/// <summary>
		///     Encountered when trying to register a user ID which is not valid.
		/// </summary>
		M_INVALID_USERNAME,

		// TODO: Ref to `createRoom` API
		/// <summary>
		///     Sent when the room alias given to the `createRoom` API is already in use.
		/// </summary>
		M_ROOM_IN_USE,

		// TODO: Ref to `createRoom` API
		/// <summary>
		///     Sent when the initial state given to the `createRoom` API is invalid.
		/// </summary>
		M_INVALID_ROOM_STATE,

		/// <summary>
		///     Sent when a threepid given to an API cannot be used because the same threepid is already in use.
		/// </summary>
		M_THREEPID_IN_USE,

		/// <summary>
		///     Sent when a threepid given to an API cannot be used because no record matching the threepid was found.
		/// </summary>
		M_THREEPID_NOT_FOUND,

		/// <summary>
		///     Authentication could not be performed on the third party identifier.
		/// </summary>
		M_THREEPID_AUTH_FAILED,

		/// <summary>
		///     The server does not permit this third party identifier. This may happen if the server only permits, for example,
		///     email addresses from a particular domain.
		/// </summary>
		M_THREEPID_DENIED,

		/// <summary>
		///     The client's request used a third party server, eg. identity server, that this server does not trust.
		/// </summary>
		M_SERVER_NOT_TRUSTED,

		/// <summary>
		///     The client's request to create a room used a room version that the server does not support.
		/// </summary>
		M_UNSUPPORTED_ROOM_VERSION,

		// TODO: create `ApiIncompatibleRoomVersionException`
		/// <summary>
		///     The client attempted to join a room that has a version the server does not support. Inspect the `room_version`
		///     property of the error response for the room's version.
		/// </summary>
		M_INCOMPATIBLE_ROOM_VERSION,

		/// <summary>
		///     The state change requested cannot be performed, such as attempting to unban a user who is not banned.
		/// </summary>
		M_BAD_STATE,

		/// <summary>
		///     The room or resource does not permit guests to access it.
		/// </summary>
		M_GUEST_ACCESS_FORBIDDEN,

		/// <summary>
		///     A Captcha is required to complete the request.
		/// </summary>
		M_CAPTCHA_NEEDED,

		/// <summary>
		///     The Captcha provided did not match what was expected.
		/// </summary>
		M_CAPTCHA_INVALID,

		/// <summary>
		///     A required parameter was missing from the request.
		/// </summary>
		M_MISSING_PARAM,

		/// <summary>
		///     A parameter that was specified has the wrong value. For example, the server expected an integer and instead
		///     received a string.
		/// </summary>
		M_INVALID_PARAM,

		/// <summary>
		///     The request or entity was too large.
		/// </summary>
		M_TOO_LARGE,

		/// <summary>
		///     The resource being requested is reserved by an application service, or the application service making the request
		///     has not created the resource.
		/// </summary>
		M_EXCLUSIVE,


		/// <summary>
		///     The request cannot be completed because the homeserver has reached a resource limit imposed on it. For example, a
		///     homeserver held in a shared hosting environment may reach a resource limit if it starts using too much memory or
		///     disk space.
		/// </summary>
		M_RESOURCE_LIMIT_EXCEEDED,

		/// <summary>
		///     The user is unable to reject an invite to join the server notices room.
		/// </summary>
		M_CANNOT_LEAVE_SERVER_NOTICE_ROOM
	}
}