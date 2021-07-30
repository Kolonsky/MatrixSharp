using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema.MsgtypeInfos
{
	/// <summary>
	///     Information on the encrypted file.
	/// </summary>
	/// <param name="Url"> The URL to the file.</param>
	/// <param name="Iv"> The 128-bit unique counter block used by AES-CTR, encoded as unpadded base64.</param>
	/// <param name="Hashes">
	///     A map from an algorithm name to a hash of the ciphertext, encoded as unpadded base64. Clients
	///     should support the SHA-256 hash, which uses the key `sha256`.
	/// </param>
	/// <param name="Version"> Version of the encrypted attachments protocol. Must be `v2`.</param>
	public record EncryptedFile(
		string Url,
		EncryptedFile.JWK Key,
		string Iv,
		Dictionary<string, string> Hashes,
		[property: JsonPropertyName("v")] string Version
	)
	{
		/// <summary>
		///     A JSON Web Key object.
		/// </summary>
		/// <param name="KeyOperations"> Key operations. Must at least contain `encrypt` and `decrypt`.</param>
		/// <param name="Key"> The key, encoded as urlsafe unpadded base64.</param>
		public record JWK(
			[property: JsonPropertyName("key_ops")]
			string[] KeyOperations,
			[property: JsonPropertyName("k")] string Key
		)
		{
			/// <summary>
			///     Key type. Must be `oct`.
			/// </summary>
			[JsonPropertyName("kty")] public const string KeyType = "oct";

			/// <summary>
			///     Algorithm. Must be `A256CTR`.
			/// </summary>
			[JsonPropertyName("alg")] public const string Algorithm = "A256CTR";

			/// <summary>
			///     Extractable. Must be `true`. This is a W3C extension.
			/// </summary>
			[JsonPropertyName("ext")] public const bool Extractable = true;
		}
	}
}