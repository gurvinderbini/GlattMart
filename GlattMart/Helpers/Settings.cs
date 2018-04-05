// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace GlattMart.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region Setting Constants

		private const string SettingsKey = "settings_key";
		private static readonly string SettingsDefault = string.Empty;

        private const string UserNameKey = "userNameKey";
        private static readonly string UserNameDefault = string.Empty;

        private const string EmailKey = "emailKey";
        private static readonly string EmailDefault = string.Empty;

        private const string LoginCompletedKey = "loginCompletedKey";
        private static readonly bool LoginCompletedDefault = false;

		#endregion


		public static string GeneralSettings
		{
			get
			{
				return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(SettingsKey, value);
			}
		}

        public static string Email
        {
            get
            {
                return AppSettings.GetValueOrDefault(EmailKey, EmailDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(EmailKey, value);
            }
        }

        public static string UserName
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserNameKey, UserNameDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserNameKey, value);
            }
        }

        public static bool LoginCompleted
        {
            get
            {
                return AppSettings.GetValueOrDefault(LoginCompletedKey, LoginCompletedDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(LoginCompletedKey, value);
            }
        }

	}
}