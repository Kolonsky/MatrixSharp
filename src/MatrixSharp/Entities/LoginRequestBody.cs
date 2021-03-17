using System.Text.Json.Serialization;

namespace MatrixSharp.Entities
{
	public class LoginRequestBody
	{
		// TODO: `type` as enum. Different constructors.
		/// <param name="type">The login type being used. One of: ["m.login.password", "m.login.token"]</param>
		/// <param name="identifier">Identification information for the user.</param>
		/// <param name="user">
		///     The fully qualified user ID or just local part of the user ID, to log in. Deprecated in favour of
		///     <see cref="IIdentifier" />.
		/// </param>
		/// <param name="medium">
		///     When logging in using a third party identifier, the medium of the identifier. Must be 'email'.
		///     Deprecated in favour of <see cref="IIdentifier" />.
		/// </param>
		/// <param name="address">Third party identifier for the user. Deprecated in favour of <see cref="IIdentifier" />.</param>
		/// <param name="passwrod">Required when `type` is `m.login.password`. The user's password.</param>
		/// <param name="token">Required when `type` is `m.login.token`. Part of Token-based login.</param>
		/// <param name="deviceId">
		///     ID of the client device. If this does not correspond to a known client device, a new device will
		///     be created. The server will auto-generate a device_id if this is not specified.
		/// </param>
		/// <param name="initialDeviceDisplayName">
		///     A display name to assign to the newly-created device. Ignored if `device_id`
		///     corresponds to a known device.
		/// </param>
		public LoginRequestBody(string type, IIdentifier? identifier = null, string? user = null, string? medium = null,
			string? address = null, string? passwrod = null, string? token = null, string? deviceId = null,
			string? initialDeviceDisplayName = null)
		{
			Type = type;
			Identifier = identifier;
			User = user;
			Medium = medium;
			Address = address;
			Passwrod = passwrod;
			Token = token;
			DeviceId = deviceId;
			InitialDeviceDisplayName = initialDeviceDisplayName;
		}

		[JsonPropertyName("type")] public string Type { get; }

		[JsonPropertyName("identifier")] public object? Identifier { get; }

		[JsonPropertyName("user")] public string? User { get; }

		[JsonPropertyName("medium")] public string? Medium { get; }

		[JsonPropertyName("address")] public string? Address { get; }

		[JsonPropertyName("password")] public string? Passwrod { get; }

		[JsonPropertyName("token")] public string? Token { get; }

		[JsonPropertyName("device_id")] public string? DeviceId { get; }

		[JsonPropertyName("initial_device_display_name")]
		public string? InitialDeviceDisplayName { get; }

		#region Identifiers

		public interface IIdentifier
		{
			public string Type { get; }
		}

		// TODO: Create a specific type in all interface implementations where needed
		/// <summary>
		///     The user is identified by their Matrix ID.
		/// </summary>
		public class UserIdentifier : IIdentifier
		{
			/// <summary>
			///     UserIdentifier constructor.
			/// </summary>
			/// <param name="user">user_id or user localpart.</param>
			public UserIdentifier(string user)
			{
				User = user;
			}

			[JsonPropertyName("user")] public string User { get; }

			[JsonPropertyName("type")] public string Type => "m.id.user";
		}

		/// <summary>
		///     The user is identified by a third-party identifier in canonicalised form.
		/// </summary>
		public class ThirdPartyIdentifier : IIdentifier
		{
			/// <summary>
			///     ThirdPartyIdentifier constructor.
			/// </summary>
			/// <param name="medium">The medium of the third party identifier.</param>
			/// <param name="address">The canonicalised third party address of the user.</param>
			public ThirdPartyIdentifier(string medium, string address)
			{
				Medium = medium;
				Address = address;
			}

			[JsonPropertyName("medium")] public string Medium { get; }

			[JsonPropertyName("address")] public string Address { get; }

			[JsonPropertyName("type")] public string Type => "m.id.thirdparty";
		}

		/// <summary>
		///     The user is identified by a phone number.
		/// </summary>
		public class PhoneNumberIdentifier : IIdentifier
		{
			/// <summary>
			///     PhoneNumberIdentifier constructor.
			/// </summary>
			/// <param name="country">The country that the phone number is from.</param>
			/// <param name="phoneNumber">The phone number.</param>
			public PhoneNumberIdentifier(string country, string phoneNumber)
			{
				Country = country;
				PhoneNumber = phoneNumber;
			}

			[JsonPropertyName("country")] public string Country { get; }

			[JsonPropertyName("phone")] public string PhoneNumber { get; }

			[JsonPropertyName("type")] public string Type => "m.id.phone";
		}

		#endregion
	}
}