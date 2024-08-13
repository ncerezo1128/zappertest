using prjZapper.Model;

namespace prjZapper.Repository.Contracts
{
    public interface IUserSettingsFunction
    {
        public bool checkSettings(string settings, int? numberOfSetting);
        Task<UploadModel> uploadInputSettings(IFormFile file);
    }
}