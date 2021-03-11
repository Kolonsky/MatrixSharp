using System.Threading.Tasks;

namespace MatrixSharp.Client.Authentication
{
	public abstract class BaseAuthentication
	{
		protected BaseAuthentication(string sessionId = null)
		{
			SessionId = sessionId;
		}

		protected abstract string Type { get; }
		protected string SessionId { get; }

		internal abstract Task<string> GetToken();
	}
}