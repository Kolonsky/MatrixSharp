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
	public record ThumbnailInfo
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
	}
}