using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema;
using MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema.MsgtypeInfos;

namespace MatrixSharp.Api.EventSchemas.Schema
{
	/// <summary>
	///     This message represents a single audio clip.
	/// </summary>
	[MatrixEventType(TYPE, MSGTYPE)]
	public record RoomAudioMessageEvent : RoomMessageEvent
	{
		private const string MSGTYPE = "m.audio";

		/// <inheritdoc cref="RoomAudioMessageEvent" />
		public RoomAudioMessageEvent(RoomMessageEvent.ContentProperty content, string eventId, string sender,
			long originServerTs, string roomId) : base(content, eventId, sender, originServerTs, roomId)
		{
		}

		/// <param name="Body">
		///     A description of the audio e.g. 'Bee Gees - Stayin' Alive', or some kind of content description for
		///     accessibility e.g. 'audio attachment'.
		/// </param>
		public new record ContentProperty(
			string Body
		) : RoomMessageEvent.ContentProperty(Body, MSGTYPE)
		{
			/// <inheritdoc cref="AudioInfo" />
			public AudioInfo? Info { get; init; }

			/// <summary>
			///     Required if the file is unencrypted. The URL to the audio clip.
			/// </summary>
			public string? Url { get; init; }

			/// <summary>
			///     Required if the file is encrypted.
			/// </summary>
			public EncryptedFile? File { get; init; }

			/// <summary>
			///     Metadata for the audio clip referred to in ``url``.
			/// </summary>
			public record AudioInfo
			{
				/// <summary>
				///     The duration of the audio in milliseconds.
				/// </summary>
				public int? Duration { get; init; }

				/// <summary>
				///     The mimetype of the audio e.g. ``audio/aac``.
				/// </summary>
				public string? Mimetype { get; init; }

				/// <summary>
				///     The size of the audio clip in bytes.
				/// </summary>
				public int? Size { get; init; }
			}
		}
	}
}