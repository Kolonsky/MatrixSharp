using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Xml;
using MatrixSharp.Api;
using MatrixSharp.Entities;
using MatrixSharp.Exceptions;

namespace MatrixSharp.Client
{
	internal class RestClient : IDisposable
	{
		public RestClient()
		{
			HttpClient = new HttpClient();
		}

		private HttpClient HttpClient { get; }

		public void Dispose()
		{
			HttpClient.Dispose();
		}

		/// <summary>
		///     Sends request to Matrix API
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

		private static void ThrowIfApiError(HttpResponseMessage response)
		{
			if (response.IsSuccessStatusCode)
				return;

			var content = response.Content;

			StandardErrorResponse contentJson;
			// TODO: Incorrect exception handling and thowing
			try
			{
				contentJson = content.ReadFromJsonAsync<StandardErrorResponse>().Result;
				if (contentJson == null)
					throw new UnexpectedApiException(
						"The server returned an unrecognizable error response. That was unexpected.", response);
			}
			catch
			{
				response.EnsureSuccessStatusCode();
				throw;
			}

			throw new ApiException(
				contentJson.ErrorMessage,
				contentJson.ErrorCode switch
				{
					ErrorCode.M_LIMIT_EXCEEDED => content.ReadFromJsonAsync<RatelimitedErrorResponse>().Result,
					_ => contentJson
				},
				response.StatusCode);
		}
	}
}