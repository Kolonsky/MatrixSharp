namespace MatrixSharp.Api.ClientServer.Definitions
{
	/// <summary>
	///     A client device
	/// </summary>
	/// <param name="DeviceId"> Identifier of this device.</param>
	public record ClientDevice(
		string DeviceId
	)
	{
		/// <summary>
		///     Display name set by the user for this device. Absent if no name has been
		///     set.
		/// </summary>
		public string? DisplayName { get; init; }

		/// <summary>
		///     The IP address where this device was last seen. (May be a few minutes out
		///     of date, for efficiency reasons).
		/// </summary>
		public string? LastSeenIp { get; init; }

		/// <summary>
		///     The timestamp (in milliseconds since the unix epoch) when this devices
		///     was last seen. (May be a few minutes out of date, for efficiency
		///     reasons).
		/// </summary>
		public long? LastSeenTs { get; init; }
	}
}