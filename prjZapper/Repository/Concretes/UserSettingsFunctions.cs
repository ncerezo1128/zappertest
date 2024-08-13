using Newtonsoft.Json;
using prjZapper.Model;
using prjZapper.Repository.Contracts;
using prjZapper.Utility;

namespace prjZapper.Repository.Concretes
{
	public class UserSettingsFunction : IUserSettingsFunction
    {
		public bool checkSettings(string settings, int? numberOfSetting)
		{
            return SettingsUtil.checkUtilitySettings(settings,numberOfSetting);
		}

        public async Task<UploadModel> uploadInputSettings(IFormFile file)
        {
            UploadModel uploadResult = new UploadModel { result = false, numberSetting = 0 };
            
            /*Check file lenght*/
            if (file == null || file.Length == 0) return uploadResult;                

            using (var stream = new StreamReader(file.OpenReadStream()))
            {
                var jsonString = await stream.ReadToEndAsync();
                var settingParams = JsonConvert.DeserializeObject<RequestModel>(jsonString);

                if (settingParams == null) return uploadResult;

                uploadResult.result = SettingsUtil.checkUtilitySettings(settingParams.settings, settingParams.numberOfSettings);
                return uploadResult;
            }
        }       
    }
}

