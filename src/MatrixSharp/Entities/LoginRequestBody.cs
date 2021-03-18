using System.Text.Json.Serialization;

namespace MatrixSharp.Entities
{
	/// <summary>
	///     Request body used to authenticate the user.
	/// </summary>
	public class LoginRequestBody
	{
		// TODO: `type` as enum. Different constructors.
		/// <param name="type"> The login type being used. One of: ["m.login.password", "m.login.token"]</param>
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

		/// <summary>
		///     The login type being used.
		/// </summary>
		[JsonPropertyName("type")]
		public string Type { get; }

		/// <inheritdoc cref="IIdentifier" />
		[JsonPropertyName("identifier")]
		public object? Identifier { get; }

		/// <summary>
		///     The fully qualified user ID or just local part of the user ID, to log in.
		/// </summary>
		[JsonPropertyName("user")]
		public string? User { get; }

		/// <summary>
		///     When logging in using a third party identifier, the medium of the identifier. Must be 'email'.
		/// </summary>
		[JsonPropertyName("medium")]
		public string? Medium { get; }

		/// <summary>
		///     Third party identifier for the user.
		/// </summary>
		[JsonPropertyName("address")]
		public string? Address { get; }

		/// <summary>
		///     The user's password.
		/// </summary>
		[JsonPropertyName("password")]
		public string? Passwrod { get; }

		/// <summary>
		///     Part of Token-based login.
		/// </summary>
		[JsonPropertyName("token")]
		public string? Token { get; }

		/// <summary>
		///     ID of the client device.
		/// </summary>
		[JsonPropertyName("device_id")]
		public string? DeviceId { get; }

		/// <summary>
		///     A display name to assign to the newly-created device.
		/// </summary>
		[JsonPropertyName("initial_device_display_name")]
		public string? InitialDeviceDisplayName { get; }

		#region Identifiers

		/// <summary>
		///     Identification information for the user.
		/// </summary>
		public interface IIdentifier
		{
			/// <summary>
			///     The type of identification.
			/// </summary>
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

			/// <summary>
			///     user_id or user localpart.
			/// </summary>
			[JsonPropertyName("user")]
			public string User { get; }

			/// <inheritdoc cref="IIdentifier.Type" />
			[JsonPropertyName("type")]
			public string Type => "m.id.user";
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

			/// <summary>
			///     The medium of the third party identifier.
			/// </summary>
			[JsonPropertyName("medium")]
			public string Medium { get; }

			/// <summary>
			///     The canonicalised third party address of the user.
			/// </summary>
			[JsonPropertyName("address")]
			public string Address { get; }

			/// <inheritdoc cref="IIdentifier.Type" />
			[JsonPropertyName("type")]
			public string Type => "m.id.thirdparty";
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

			/// <summary>
			///     The country that the phone number is from.
			/// </summary>
			[JsonPropertyName("country")]
			public string Country { get; }

			/// <summary>
			///     The phone number.
			/// </summary>
			[JsonPropertyName("phone")]
			public string PhoneNumber { get; }

			/// <inheritdoc cref="IIdentifier.Type" />
			[JsonPropertyName("type")]
			public string Type => "m.id.phone";
		}

		#endregion
	}
}