using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable disable
namespace MatrixSharp.Client
{
	internal class RestRequest : HttpRequestMessage
	{
		public RestRequest(HttpMethod method, Uri route, string accessToken = null) : base(method, route)
		{
			if (accessToken != null) Headers.Authorization = AuthenticationHeaderValue.Parse("Bearer " + accessToken);
		}

		public RestRequest(HttpMethod method, Uri route, object payload, string accessToken = null) : this(method,
			route, accessToken)
		{
			// Use EnumMemberAttribute to parse enum member value
			var options = new JsonSerializerOptions
			{
				Converters = {new JsonStringEnumMemberConverter()}
			};
			Content = new StringContent(JsonSerializer.Serialize(payload, options));
		}

		public RestRequest(HttpMethod method, Uri route, Stream payload, string accessToken = null) : this(method,
			route, accessToken)
		{
			Content = new StreamContent(payload);
		}
	}
}