namespace MatrixSharp.Entities.Events
{
	public class EventContent
	{
		public EventContent(MembershipEnum membership)
		{
			Membership = membership;
		}

		/// <summary>
		///     The avatar URL for this user, if any.
		/// </summary>
		public string? AvatarUrl { get; set; }

		/// <summary>
		///     The display name for this user, if any.
		/// </summary>
		public string? Displayname { get; set; }

		/// <summary>
		///     The membership state of the user. One of: ["invite", "join", "knock", "leave", "ban"]
		/// </summary>
		public MembershipEnum Membership { get; }
	}

	/// <summary>
	///     The membership state of the user.
	/// </summary>
	public enum MembershipEnum
	{
		/// <summary>
		///     User invited.
		/// </summary>
		Invite,

		/// <summary>
		///     User joined.
		/// </summary>
		Join,

		/// <summary>
		///     Knock-knock. Who's there?
		/// </summary>
		Knock,

		/// <summary>
		///     User leaved.
		/// </summary>
		Leave,

		/// <summary>
		///     User banned.
		/// </summary>
		Ban
	}
}