using MatrixSharp.Api;
using MatrixSharp.Entities;
using MatrixSharp.Exceptions;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace MatrixSharp.Client
{
	public class MatrixApiClient
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

		/// <summary>
		///     Gets discovery information about the domain.
		/// </summary>
		/// <returns>Server discovery information.</returns>
		/// <exception cref="HttpRequestException"></exception>
		/// <exception cref="ApiException"></exception>
		/// <exception cref="UnexpectedApiException"></exception>
		public async Task<WellKnownResponse> GetWellKnownAsync() =>
			await DoRequestAsync<WellKnownResponse>(new RestRequest(HttpMethod.Get,
				new Uri(Homeserver, Endpoint.WELLKNOWN)));

		#endregion

		#region Client Authentication

		#region Login

		/// <summary>
		///     Gets the homeserver's supported login types to authenticate users. Clients should pick one of these and supply it as the <see cref="LoginFlow"/> when logging in.
		/// </summary>
		/// <returns>The login types the homeserver supports.</returns>
		/// <exception cref="HttpRequestException"></exception>
		/// <exception cref="ApiException"></exception>
		/// <exception cref="UnexpectedApiException"></exception>
		public async Task<LoginTypes> GetLoginTypes() =>
			await DoRequestAsync<LoginTypes>(new RestRequest(HttpMethod.Get, 
				new Uri(Homeserver, Endpoint.LOGIN)));

		public async Task<LoginResponse> Login(LoginBody body)
		{
			return await DoRequestAsync<LoginResponse>(new RestRequest(HttpMethod.Post,
				new Uri(Homeserver, Endpoint.LOGIN), JsonDocument.Parse(body.ToString())));
		}

		#endregion

		#region Account registration and management

		//public async Task<object> DeactivateAccount()

		#endregion

		#endregion

		private async Task<T> DoRequestAsync<T>(RestRequest request)
		{
			var response = await RestClient.SendRequestAsync(request);
			var asReturnType = await response.Content.ReadFromJsonAsync<T>();

			return asReturnType;
		}

	}
}