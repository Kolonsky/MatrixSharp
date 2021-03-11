using MatrixSharp.Net.Api;
using MatrixSharp.Net.Api.Exceptions;
using MatrixSharp.Net.Entities;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MatrixSharp.Net
{
	internal class RestClient //: IDisposable
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
		/// <exception cref="ApiRatelimitedException"></exception>
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

			var asJson = await response.Content.ReadFromJsonAsync<StandardErrorResponse>();
			if (asJson != null)
				switch (asJson.ErrorCode)
				{
					case ErrorCode.M_LIMIT_EXCEEDED:
						{
							var ratelimitedError = await response.Content.ReadFromJsonAsync<RatelimitedErrorResponse>();
							throw new ApiRatelimitedException(ratelimitedError.ErrorMessage, ratelimitedError.ErrorCode,
								TimeSpan.FromMilliseconds(ratelimitedError.RetryAfterMs), response.StatusCode);
						}
					default:
						{
							var standardError = await response.Content.ReadFromJsonAsync<StandardErrorResponse>();
							throw new ApiException(standardError.ErrorMessage, standardError.ErrorCode,
								response.StatusCode);
						}
				}

			throw new UnexpectedApiException("The server returned an unrecognizable error response. That was unexpected.", response);
		}
	}
}