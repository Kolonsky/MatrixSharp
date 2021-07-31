using System.Collections.Generic;

namespace MatrixSharp.Api.ClientServer.Definitions
{
	/// <summary>
	///     A signature of an ``m.third_party_invite`` token to prove that this user
	///     owns a third party identity which has been invited to the room.
	/// </summary>
	/// <param name="Sender"> The Matrix ID of the user who issued the invite.</param>
	/// <param name="Mxid"> The Matrix ID of the invitee.</param>
	/// <param name="Token"> The state key of the m.third_party_invite event.</param>
	public record ThirdPartySigned(
		string Sender,
		string Mxid,
		string Token,
		ThirdPartySigned.SignaturesProp Signatures
	)
	{
		/// <summary>
		///     A signatures object containing a signature of the entire signed object.
		/// </summary>
		public class SignaturesProp : Dictionary<string, IDictionary<string, string?>?>
		{
		}
	}
}