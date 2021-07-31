namespace MatrixSharp.Api.ClientServer.Definitions.Errors
{
	public record RateLimitedError() : MatrixError(ERRCODE)
	{
		private const string ERRCODE = "M_LIMIT_EXCEEDED";
		public new string Errcode => ERRCODE;

		/// <summary>
		///     The amount of time in milliseconds the client should wait
		///     before trying the request again.
		/// </summary>
		public int? RetryAfterMs { get; init; }
	}
}