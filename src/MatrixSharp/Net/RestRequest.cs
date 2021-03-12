using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MatrixSharp.Net
{
	internal class RestRequest : HttpRequestMessage
	{
		public RestRequest(HttpMethod method, string route, string accessToken = null) : base(method, route)
		{
			Headers.Authorization = AuthenticationHeaderValue.Parse(accessToken);
		}

		public RestRequest(HttpMethod method, string route, string payload, string accessToken = null) : this(method,
			route, accessToken)
		{
			Content = new StringContent(payload);
		}

		public RestRequest(HttpMethod method, string route, Stream payload, string accessToken = null) : this(method,
			route, accessToken)
		{
			throw new NotImplementedException();
		}
	}
}