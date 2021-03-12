using MatrixSharp.Net.Api;
using MatrixSharp.Net.Api.Exceptions;
using MatrixSharp.Net.Entities;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MatrixSharp.Net
{
	internal sealed class RestClient : IDisposable
	{
		public RestClient()
		{
			HttpClient = new HttpClient();
		}

		private HttpClient HttpClient { get; }

		/// <summary>
		/// Sends request to Matrix API
		/// </summary>
		/// <param name="request">API request object</param>
		/// <returns>Http response</returns>
		/// <exception cref="HttpRequestException"></exception>
		/// <exception cref="ApiException"></exception>
		/// <exception cref="UnexpectedApiException"></exception>
		public async Task<HttpResponseMessage> SendRequestAsync(RestRequest request)
		{
			var response = await HttpClient.SendAsync(request);
			ThrowIfApiError(response);

			return response;
		}

		private static async void ThrowIfApiError(HttpResponseMessage response)
		{
			if (response.IsSuccessStatusCode)
				return;

			var content = response.Content;
			System.Diagnostics.Debug.WriteLine(content.ReadAsStringAsync().Result);
			StandardErrorResponse contentJson;
			try
			{
				contentJson = await content.ReadFromJsonAsync<StandardErrorResponse>();
			}
			catch
			{
				response.EnsureSuccessStatusCode();
				throw;
			}

			if (contentJson == null)
				throw new UnexpectedApiException(
					"The server returned an unrecognizable error response. That was unexpected.", response);

			throw new ApiException(
				contentJson.ErrorMessage,
				contentJson.ErrorCode switch
				{
					ErrorCode.M_LIMIT_EXCEEDED => await content.ReadFromJsonAsync<RatelimitedErrorResponse>(),
					_ => contentJson
				},
				response.StatusCode);
		}

		public void Dispose()
		{
			HttpClient.Dispose();
		}
	}
}