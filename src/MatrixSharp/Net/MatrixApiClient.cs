using MatrixSharp.Net.Api;
using MatrixSharp.Net.Api.Exceptions;
using MatrixSharp.Net.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MatrixSharp.Net
{
	public class MatrixApiClient
	{
		private RestClient RestClient { get; init; }

		/// <summary>
		/// Homeserver url
		/// </summary>
		public Uri Homeserver { get; init; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="homeserver">Homeserver url</param>
		public MatrixApiClient(Uri homeserver)
		{
			// TODO: check for valid url
			Homeserver = homeserver;

			RestClient = new RestClient();
		}

		#region API Standards

		/// <summary>
		/// Gets the versions of the specification supported by the server.
		/// </summary>
		/// <returns>The versions supported by the server.</returns>
		/// <exception cref="HttpRequestException"></exception>
		/// <exception cref="ApiException"></exception>
		/// <exception cref="UnexpectedApiException"></exception>
		public async Task<ClientVersions> GetClientVersionsAsync()
		{
			var request = new RestRequest(HttpMethod.Get, new Uri(Homeserver, Endpoint.VERSIONS));
			System.Diagnostics.Debug.WriteLine(request.RequestUri);
			var response = await RestClient.SendRequestAsync(request);
			var asReturnType = await response.Content.ReadFromJsonAsync<ClientVersions>();

			return asReturnType;
		}

		public async Task<ClientVersions> GetMatrixError()
		{
			var request = new RestRequest(HttpMethod.Get, new Uri(Homeserver, "1234"));
			System.Diagnostics.Debug.WriteLine(request.RequestUri);
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
