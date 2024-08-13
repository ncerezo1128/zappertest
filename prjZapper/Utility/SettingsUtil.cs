namespace prjZapper.Utility
{
	public static class SettingsUtil
	{
        public static bool checkUtilitySettings(string settings, int? numberOfSetting)
        {
            bool res = false;
            if (numberOfSetting > settings.Length + 1) return res;

            for (int numCtr = 0; numCtr < settings.Length; numCtr++)
            {
                if (numCtr == numberOfSetting - 1)
                {
                    res = (settings.Substring(numCtr, 1) == "1");
                    return res;
                }
            }
            return res;
        }
    }
}

