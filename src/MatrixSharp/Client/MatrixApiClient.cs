using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MatrixSharp.Api;
using MatrixSharp.Entities;
using MatrixSharp.Exceptions;

namespace MatrixSharp.Client
{
	/// <summary>
	///     Client for accessing Matrix endpoints.
	/// </summary>
	public class MatrixApiClient
	{
		#region Constructor and fields

		/// <summary>
		///     Creates an instance of MatrixApiClient.
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
		private Uri Homeserver { get; }

		#endregion

		#region API Standards

		/// <summary>
		///     Gets the versions of the specification supported by the server.
		/// </summary>
		/// <returns>The versions supported by the server.</returns>
		/// <inheritdoc cref="DoRequestAsync{T}" />
		public async Task<ClientVersionsResponse> GetClientVersionsAsync()
		{
			return await DoRequestAsync<ClientVersionsResponse>(new RestRequest(HttpMethod.Get,
				new Uri(Homeserver, Endpoint.VERSIONS)));
		}

		#endregion

		#region Server Discovery

		/// <summary>
		///     Gets discovery information about the domain.
		/// </summary>
		/// <returns>Server discovery information.</returns>
		/// <inheritdoc cref="DoRequestAsync{T}" />
		public async Task<WellKnownResponse?> GetWellKnownAsync()
		{
			try
			{
				return await DoRequestAsync<WellKnownResponse>(new RestRequest(HttpMethod.Get,
					new Uri(Homeserver, Endpoint.WELLKNOWN)));
			}
			catch (HttpRequestException e)
			{
				if (e.StatusCode == HttpStatusCode.NotFound)
					return null;
				throw;
			}
		}

		#endregion

		#region Client Authentication

		#region Login

		/// <summary>
		///     Gets the homeserver's supported login types to authenticate users. Clients should pick one of these and supply it
		///     as the `type` when logging in.
		/// </summary>
		/// <returns>The login types the homeserver supports.</returns>
		/// <inheritdoc cref="DoRequestAsync{T}" />
		public async Task<LoginTypesResponse> GetLoginTypes()
		{
			return await DoRequestAsync<LoginTypesResponse>(new RestRequest(HttpMethod.Get,
				new Uri(Homeserver, Endpoint.LOGIN)));
		}

		/// <summary>
		///     Authenticates the user, and issues an access token they can use to authorize themself in subsequent requests.
		/// </summary>
		/// <returns></returns>
		public async Task<LoginResponse> Login(LoginRequest request)
		{
			return await DoRequestAsync<LoginResponse>(new RestRequest(HttpMethod.Post,
				new Uri(Homeserver, Endpoint.LOGIN), request));
		}

		#endregion

		#region Account registration and management

		//public async Task<object> DeactivateAccount()

		#endregion

		#endregion

		#region Tools

#nullable disable
		/// <exception cref="HttpRequestException"></exception>
		/// <exception cref="ApiException"></exception>
		/// <exception cref="UnexpectedApiException"></exception>
		private async Task<T> DoRequestAsync<T>(RestRequest request)
		{
			var response = await RestClient.SendRequestAsync(request);

			// Use EnumMemberAttribute to parse enum member value
			var options = new JsonSerializerOptions
			{
				Converters = {new JsonStringEnumMemberConverter()}
			};
			var asReturnType = await response.Content.ReadFromJsonAsync<T>(options);

			return asReturnType;
		}
#nullable restore

		#endregion
	}
}