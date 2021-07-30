namespace MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema.MsgtypeInfos
{
	/// <summary>
	///     Metadata about an image.
	/// </summary>
	public record ImageInfo
	{
		/// <summary>
		///     The intended display height of the image in pixels. This may
		///     differ from the intrinsic dimensions of the image file.
		/// </summary>
		public int? H { get; init; }

		/// <summary>
		///     The intended display width of the image in pixels. This may
		///     differ from the intrinsic dimensions of the image file.
		/// </summary>
		public int? W { get; init; }

		/// <summary>
		///     The mimetype of the image, e.g. ``image/jpeg``.
		/// </summary>
		public string? Mimetype { get; init; }

		/// <summary>
		///     Size of the image in bytes.
		/// </summary>
		public int? Size { get; init; }

		/// <summary>
		///     The URL to a thumbnail of the image.
		///     Only present if the thumbnail is unencrypted.
		/// </summary>
		public string? ThumbnailUrl { get; init; }

		/// <summary>
		///     Information on the encrypted thumbnail file.
		///     Only present if the thumbnail is encrypted.
		/// </summary>
		public EncryptedFile? ThumbnailFile { get; init; }

		/// <summary>
		///     Metadata about the image referred to in ``thumbnail_url``.
		/// </summary>
		public ThumbnailInfo? ThumbnailInfo { get; init; }
	}
}