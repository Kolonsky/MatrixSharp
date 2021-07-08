using System.Text.Json.Serialization;
using MatrixSharp.Models.Events.MatrixEventContent.InstantMessaging.Encryption;

namespace MatrixSharp.Models.Events.MatrixEventContent.InstantMessaging
{
	/// <summary>
	///     This message represents a single audio clip.
	/// </summary>
	public class MRoomMessageAudio : MRoomMessage
	{
		/// <inheritdoc cref="MRoomMessageAudio" />
		public MRoomMessageAudio(string body, MessageTypeEnum messageType) : base(body, messageType)
		{
		}

		/// <inheritdoc cref="AudioInfo" />
		[JsonPropertyName("info")]
		public AudioInfo? Info { get; set; }

		/// <summary>
		///     Required if the file is unencrypted.
		/// </summary>
		[JsonPropertyName("url")]
		public string? Url { get; set; }

		/// <inheritdoc cref="EncryptedFile" />
		/// <remarks> 	Required if the file is encrypted.</remarks>
		[JsonPropertyName("file")]
		public EncryptedFile? File { get; set; }

		#region Models

		/// <summary>
		///     Metadata for the audio clip referred to in `url`.
		/// </summary>
		public class AudioInfo
		{
			/// <summary>
			///     The duration of the audio in milliseconds.
			/// </summary>
			[JsonPropertyName("duration")]
			public ulong? Duration { get; set; }

			/// <summary>
			///     The mimetype of the audio e.g. `audio/aac`.
			/// </summary>
			[JsonPropertyName("mimetype")]
			public string? MimeType { get; set; }

			/// <summary>
			///     The size of the audio clip in bytes.
			/// </summary>
			[JsonPropertyName("size")]
			public ulong? Size { get; set; }
		}

		#endregion
	}
}