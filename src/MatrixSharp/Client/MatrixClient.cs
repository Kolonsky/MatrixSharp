using System.Threading.Tasks;
using MatrixSharp.Client.Authentication;
using MatrixSharp.Net;

namespace MatrixSharp.Client
{
	public class MatrixClient
	{
		private	RestClient RestClient { get; init; }
		public MatrixClient(BaseAuthentication auth)
		{
			Auth = auth;
			RestClient = new RestClient();
		}

		public BaseAuthentication Auth { get; }
		public string Homeserver { get; private set; }
		private string Token { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public async Task Authenticate()
		{
			Token = await Auth.GetToken();
		}
	}
}