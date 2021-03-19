using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MatrixSharp.Entities;
using MatrixSharp.Entities.Responses;
using MatrixSharp.Exceptions;

namespace MatrixSharp.Client
{
	internal static class RestClient
	{
		/// <summary>
		///     Sends request to Matrix API
		/// </summary>
		/// <param name="request">API request object</param>
		/// <returns>Http response</returns>
		/// <exception cref="HttpRequestException"></exception>
		/// <exception cref="ApiException"></exception>
		/// <exception cref="UnexpectedApiException"></exception>
		public static async Task<HttpResponseMessage> SendRequestAsync(RestRequest request)
		{
			using HttpClient httpClient = new();
			var response = await httpClient.SendAsync(request);
			ThrowIfApiError(response);

			return response;
		}

		private static void ThrowIfApiError(HttpResponseMessage response)
		{
			if (response.IsSuccessStatusCode)
				return;

			var content = response.Content;

			if (content.Headers.ContentLength == 0) response.EnsureSuccessStatusCode();

			StandardErrorResponse contentJson;
			// Use EnumMemberAttribute to parse enum member value
			var options = new JsonSerializerOptions
			{
				Converters = {new JsonStringEnumMemberConverter()}
			};

			try
			{
				contentJson = content.ReadFromJsonAsync<StandardErrorResponse>(options).Result!;
			}
			catch
			{
				System.Diagnostics.Debug.WriteLine(
					$"Got unrecognizable response. Response: {response.Content.ReadAsStringAsync().Result}");
				throw new UnexpectedApiException(
					"The server returned an unrecognizable error response.", response);
			}

			throw new ApiException(contentJson.ErrorMessage, contentJson, response.StatusCode);
		}
	}
}