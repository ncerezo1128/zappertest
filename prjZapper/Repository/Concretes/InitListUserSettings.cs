using prjZapper.Repository.Contracts;

namespace prjZapper.Repository.Concretes
{
	public class InitListUserSettings : IInitListUserSettings
    {
		private readonly List<UserSettings> _userSettings;

		public InitListUserSettings(List<UserSettings> userSettings)
		{
			_userSettings = userSettings;
        }

		public List<UserSettings> GetListUserSettings()
		{
			return _userSettings;
        }
	}
}

