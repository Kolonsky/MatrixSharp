using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

#nullable disable
namespace MatrixSharp.Client
{
	internal class RestRequest : HttpRequestMessage
	{
		public RestRequest(HttpMethod method, Uri route, string accessToken = null) : base(method, route)
		{
			if (accessToken != null) Headers.Authorization = AuthenticationHeaderValue.Parse(accessToken);
		}

		public RestRequest(HttpMethod method, Uri route, object payload, string accessToken = null) : this(method,
			route, accessToken)
		{
			Content = new StringContent(JsonSerializer.Serialize(payload));
		}

		public RestRequest(HttpMethod method, Uri route, Stream payload, string accessToken = null) : this(method,
			route, accessToken)
		{
			Content = new StreamContent(payload);
		}
	}
}