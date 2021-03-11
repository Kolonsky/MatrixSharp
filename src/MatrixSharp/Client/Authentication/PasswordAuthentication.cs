using System;
using System.Threading.Tasks;

namespace MatrixSharp.Client.Authentication
{
	public class PasswordAuthentication : BaseAuthentication
	{
		public PasswordAuthentication(IIdentifier identifier, string password, string sessionId = null)
			: base(sessionId)
		{
			Identifier = identifier;
			Password = password;
			SessionId = sessionId;
		}


		protected override string Type => "m.login.password";
		private IIdentifier Identifier { get; }
		private string Password { get; }
		private string SessionId { get; }

		internal override async Task<string> GetToken()
		{
			// TODO: Implement getting token
			throw new NotImplementedException();
			var result = await Task.Run(() => "Hash is hui");
			return result;
		}
	}
}