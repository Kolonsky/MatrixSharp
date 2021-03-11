namespace MatrixSharp.Client.Authentication
{
	public interface IIdentifier
	{
		string Type { get; }
	}

	public record UserIdentifier(string User) : IIdentifier
	{
		public string Type => "m.id.user";
	}

	public record ThirdPartyIdentifier(string Medium, string Address) : IIdentifier
	{
		public string Type => "m.id.thirdparty";
	}

	public record PhoneIdentifier(string Country, string Phone) : IIdentifier
	{
		public string Type => "m.id.phone";
	}
}