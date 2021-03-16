using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MatrixSharp.Client
{
	internal class RestRequest : HttpRequestMessage
	{
		public RestRequest(HttpMethod method, Uri route, string accessToken = null) : base(method, route)
		{
			if (accessToken != null) Headers.Authorization = AuthenticationHeaderValue.Parse(accessToken);
		}

		public RestRequest(HttpMethod method, Uri route, JsonDocument payload, string accessToken = null) : this(method,
			route, accessToken)
		{
			Content = new StringContent(payload.ToString() ?? string.Empty);
		}

		public RestRequest(HttpMethod method, Uri route, Stream payload, string accessToken = null) : this(method,
			route, accessToken)
		{
			Content = new StreamContent(payload);
		}
	}
}