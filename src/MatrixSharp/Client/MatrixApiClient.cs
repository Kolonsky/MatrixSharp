using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MatrixSharp.Api;
using MatrixSharp.Entities;
using MatrixSharp.Exceptions;

namespace MatrixSharp.Client
{
	public class MatrixApiClient : IDisposable
	{
		/// <summary>
		/// </summary>
		/// <param name="homeserver">Homeserver url</param>
		public MatrixApiClient(Uri homeserver)
		{
			// TODO: check for valid url
			Homeserver = homeserver;

			RestClient = new RestClient();
		}

		private RestClient RestClient { get; }

		/// <summary>
		///     Homeserver url
		/// </summary>
		public Uri Homeserver { get; init; }

		public void Dispose()
		{
			RestClient?.Dispose();
		}

		#region API Standards

		/// <summary>
		///     Gets the versions of the specification supported by the server.
		/// </summary>
		/// <returns>The versions supported by the server.</returns>
		/// <exception cref="HttpRequestException"></exception>
		/// <exception cref="ApiException"></exception>
		/// <exception cref="UnexpectedApiException"></exception>
		public async Task<ClientVersions> GetClientVersionsAsync()
		{
			var request = new RestRequest(HttpMethod.Get, new Uri(Homeserver, Endpoint.VERSIONS));
			var response = await RestClient.SendRequestAsync(request);
			var asReturnType = await response.Content.ReadFromJsonAsync<ClientVersions>();

			return asReturnType;
		}

		#endregion

		#region Server Discovery

		#endregion

		#region Client Authentication

		#endregion
	}
}