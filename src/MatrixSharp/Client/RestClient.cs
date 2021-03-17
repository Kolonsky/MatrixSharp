using MatrixSharp.Entities;
using MatrixSharp.Exceptions;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

#nullable disable
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
			var options = new JsonSerializerOptions
			{
				// Using Enum member name instead of value
				Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
			};

			try
			{
				contentJson = content.ReadFromJsonAsync<StandardErrorResponse>(options).Result;
			}
			catch
			{
				throw new UnexpectedApiException(
					"The server returned an unrecognizable error response.", response);
			}

			throw new ApiException(contentJson.ErrorMessage, contentJson, response.StatusCode);
		}
	}
}