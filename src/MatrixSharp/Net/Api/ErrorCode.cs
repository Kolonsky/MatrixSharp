namespace MatrixSharp.Net.Api
{
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
		M_LIMIT_EXCEEDED
	}
}