using System.Collections.Generic;

namespace MatrixSharp.Api.ClientServer.Definitions
{
	/// <summary>
	///     Device identity keys
	/// </summary>
	/// <param name="UserId">
	///     The ID of the user the device belongs to. Must match the user ID used
	///     when logging in.
	/// </param>
	/// <param name="DeviceId">
	///     The ID of the device these keys belong to. Must match the device ID used
	///     when logging in.
	/// </param>
	/// <param name="Algorithms"> The encryption algorithms supported by this device.</param>
	/// <param name="Keys">
	///     Public identity keys. The names of the properties should be in the
	///     format ``&lt;algorithm&gt;:&lt;device_id&gt;``. The keys themselves should be
	///     encoded as specified by the key algorithm.
	/// </param>
	public record DeviceKeys(
		string UserId,
		string DeviceId,
		string[] Algorithms,
		IDictionary<string, string> Keys,
		DeviceKeys.SignaturesProp Signatures
	)
	{
		/// <summary>
		///     Signatures for the device key object. A map from user ID, to a map from
		///     ``&lt;algorithm&gt;:&lt;device_id&gt;`` to the signature.
		/// </summary>
		public class SignaturesProp : Dictionary<string, IDictionary<string, string?>?>
		{
		}
	}
}