using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MatrixSharp.Models.Events.MatrixEventContent.InstantMessaging.Encryption
{
	/// <summary>
	///     Information on the encrypted file.
	/// </summary>
	public class EncryptedFile
	{
		/// <see cref="EncryptedFile" />
		public EncryptedFile(string url, JWK key, string iv, Dictionary<string, string> hashes, string version)
		{
			Url = url;
			Key = key;
			Iv = iv;
			Hashes = hashes;
			Version = version;
		}

		/// <summary>
		///     The URL to the file.
		/// </summary>
		[JsonPropertyName("url")]
		public string Url { get; }

		/// <inheritdoc cref="JWK" />
		[JsonPropertyName("key")]
		public JWK Key { get; }

		/// <summary>
		///     The 128-bit unique counter block used by AES-CTR, encoded as unpadded base64.
		/// </summary>
		[JsonPropertyName("iv")]
		public string Iv { get; }

		/// <summary>
		///     A map from an algorithm name to a hash of the ciphertext, encoded as unpadded base64. Clients should support the
		///     SHA-256 hash, which uses the key `sha256`.
		/// </summary>
		[JsonPropertyName("hashes")]
		public Dictionary<string, string> Hashes { get; }

		/// <summary>
		///     Version of the encrypted attachments protocol. Must be `v2`.
		/// </summary>
		[JsonPropertyName("v")]
		public string Version { get; }

		#region Models

		/// <summary>
		///     A JSON Web Key object.
		/// </summary>
		public class JWK
		{
			/// <inheritdoc cref="JWK" />
			public JWK(string keyType, string[] keyOperations, string algorithm, string key, bool extractable)
			{
				KeyType = keyType;
				KeyOperations = keyOperations;
				Algorithm = algorithm;
				Key = key;
				Extractable = extractable;
			}

			/// <summary>
			///     Key type. Must be `oct`.
			/// </summary>
			[JsonPropertyName("kty")]
			public string KeyType { get; }

			/// <summary>
			///     Key operations. Must at least contain `encrypt` and `decrypt`.
			/// </summary>
			[JsonPropertyName("key_ops")]
			public string[] KeyOperations { get; }

			/// <summary>
			///     Algorithm. Must be `A256CTR`.
			/// </summary>
			[JsonPropertyName("alg")]
			public string Algorithm { get; }

			/// <summary>
			///     The key, encoded as urlsafe unpadded base64.
			/// </summary>
			[JsonPropertyName("k")]
			public string Key { get; }

			/// <summary>
			///     Extractable. Must be `true`. This is a W3C extension.
			/// </summary>
			[JsonPropertyName("ext")]
			public bool Extractable { get; }
		}

		#endregion
	}
}