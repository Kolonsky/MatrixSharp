using System.Threading.Tasks;
using MatrixSharp.Client.Authentication;

namespace MatrixSharp.Client
{
	public class MatrixClient
	{
		public MatrixClient(BaseAuthentication auth)
		{
			Auth = auth;
		}

		public BaseAuthentication Auth { get; }
		public string Homeserver { get; private set; }
		private string Token { get; set; }
		public bool Ratelimited { get; internal set; }

		public async Task Authenticate()
		{
			Token = await Auth.GetToken();
		}
	}
}