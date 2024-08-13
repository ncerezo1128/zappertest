using System;
namespace prjZapper
{
	public class UserSettings
	{
        private int numberSetting;
        //private bool isEnabled;
        private string? functionSetting;

        public int NumberSetting
        {
            get { return numberSetting; }
            set { numberSetting = value; }
        }

        //public bool IsEnabled
        //{
        //    get { return isEnabled; }
        //    set { isEnabled = value; }
        //}

        public string? FunctionSetting
        {
            get { return functionSetting; }
            set { functionSetting = value; }
        }
    }
}

