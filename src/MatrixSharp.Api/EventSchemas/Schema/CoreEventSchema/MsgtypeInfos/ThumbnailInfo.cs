namespace MatrixSharp.Api.EventSchemas.Schema.CoreEventSchema.MsgtypeInfos
{
	/// <summary>
	///     Metadata about a thumbnail image.
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
	public record ThumbnailInfo(
		int H,
		int W,
		string Mimetype,
		int Size
	);
}