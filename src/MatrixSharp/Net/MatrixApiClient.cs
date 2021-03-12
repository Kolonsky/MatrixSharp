using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using MatrixSharp.Net.Api;
using MatrixSharp.Net.Api.Exceptions;
using MatrixSharp.Net.Entities;

namespace MatrixSharp.Net
{
	public class MatrixApiClient
	{
		private RestClient RestClient { get; init; }

		public MatrixApiClient()
		{
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
			var request = new RestRequest(HttpMethod.Get, Endpoint.VERSIONS);
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
