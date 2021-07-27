namespace MatrixSharp.Api.ClientServer.Definitions
{
	/// <summary>
	///     A client device
	/// </summary>
	/// <param name="DeviceId"> Identifier of this device.</param>
	/// <param name="DisplayName">
	///     Display name set by the user for this device. Absent if no name has been
	///     set.
	/// </param>
	/// <param name="LastSeenIp">
	///     The IP address where this device was last seen. (May be a few minutes out
	///     of date, for efficiency reasons).
	/// </param>
	/// <param name="LastSeenTs">
	///     The timestamp (in milliseconds since the unix epoch) when this devices
	///     was last seen. (May be a few minutes out of date, for efficiency
	///     reasons).
	/// </param>
	public record Device(
		string DeviceId,
		string? DisplayName,
		string? LastSeenIp,
		long? LastSeenTs
	);
}