namespace MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema.MsgtypeInfos
{
	/// <summary>
	///     Metadata about an image.
	/// </summary>
	/// <param name="H">
	///     The intended display height of the image in pixels. This may
	///     differ from the intrinsic dimensions of the image file.
	/// </param>
	/// <param name="W">
	///     The intended display width of the image in pixels. This may
	///     differ from the intrinsic dimensions of the image file.
	/// </param>
	/// <param name="Mimetype"> The mimetype of the image, e.g. ``image/jpeg``.</param>
	/// <param name="Size"> Size of the image in bytes.</param>
	/// <param name="ThumbnailUrl">
	///     The URL to a thumbnail of the image.
	///     Only present if the thumbnail is unencrypted.
	/// </param>
	/// <param name="ThumbnailFile">
	///     Information on the encrypted thumbnail file.
	///     Only present if the thumbnail is encrypted.
	/// </param>
	/// <param name="ThumbnailInfo"> Metadata about the image referred to in ``thumbnail_url``.</param>
	public record ImageInfo(
		int H,
		int W,
		string Mimetype,
		int Size,
		string ThumbnailUrl,
		EncryptedFile ThumbnailFile,
		ThumbnailInfo ThumbnailInfo
	);
}