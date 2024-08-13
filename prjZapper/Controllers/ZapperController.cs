using Microsoft.AspNetCore.Mvc;
using prjZapper.Repository.Contracts;
using prjZapper.Model;
using Newtonsoft.Json;

namespace prjZapper.Controllers;

[ApiController]
[Route("[controller]")]
public class ZapperController : ControllerBase
{

    private IUserSettingsFunction _userSettingsFunction;
    private IInitListUserSettings _initListUserSettings;

    public ZapperController(IUserSettingsFunction userSettingsFunction,
                            IInitListUserSettings initListUserSettings)
    {
        _userSettingsFunction = userSettingsFunction;
        _initListUserSettings = initListUserSettings;
    }

    [HttpPost]
    [Route("CheckUserSettings")]
    public IActionResult CheckUserSettings(RequestModel request)
    {
        try
        {
            bool result = _userSettingsFunction.checkSettings(request.settings, request.numberOfSettings);
            string? settingsType = _initListUserSettings.GetListUserSettings().Where(x => x.NumberSetting == request.numberOfSettings).FirstOrDefault(new UserSettings { NumberSetting = 0 , FunctionSetting  = "DEFAUL IS NONE" }).FunctionSetting;

            if (result)
            {
                return Ok(new ResponseModel<bool> { result = result, code = 200, settingsDescription = settingsType  + " - ON"});
            }

            return BadRequest(new ResponseModel<bool> { result = result, code = 500, settingsDescription = settingsType + " - OFF" });            
        }
        catch(Exception ex)
        {
            throw new Exception("Error", ex);
        }        
    }

    [HttpPost("uploadUserSettings")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        try
        {
            UploadModel uploadResult = await _userSettingsFunction.uploadInputSettings(file);
            string? settingsType = _initListUserSettings.GetListUserSettings().Where(x => x.NumberSetting == uploadResult.numberSetting).FirstOrDefault(new UserSettings { NumberSetting = 0, FunctionSetting = "DEFAUL IS NONE" }).FunctionSetting;

            if (uploadResult.result)
            {
                return Ok(new ResponseModel<bool> { result = uploadResult.result, code = 200, settingsDescription = settingsType + " - ON" });
            }

            return BadRequest(new ResponseModel<bool> { result = uploadResult.result, code = 500, settingsDescription = settingsType + " - OFF" });
        }
        catch (Exception ex)
        {
            throw new Exception("Error", ex);
        }  
    }


    [HttpPost("generateUserSettings")]  
    public IActionResult generateUserSettings(RequestModel request)
    {        
        try
        {
            bool result = _userSettingsFunction.checkSettings(request.settings, request.numberOfSettings);
            string? settingsType = _initListUserSettings.GetListUserSettings().Where(x => x.NumberSetting == request.numberOfSettings).FirstOrDefault(new UserSettings { NumberSetting = 0, FunctionSetting = "DEFAUL IS NONE" }).FunctionSetting;

            ResponseModel<bool> fileResult = new ResponseModel<bool> { result = result, code = 500, settingsDescription = settingsType + " - OFF" };

            if (result)
            {
                fileResult = new ResponseModel<bool> { result = result, code = 200, settingsDescription = settingsType + " - ON" };
            }
           
            // Serialize the data to JSON
            var jsonString = JsonConvert.SerializeObject(fileResult);

            // Convert the JSON string to a byte array
            var fileBytes = System.Text.Encoding.UTF8.GetBytes(jsonString);

            // Create a file result to return as a downloadable file
            return File(fileBytes, "application/json", fileResult.settingsDescription + " Zapper.json");

        }
        catch (Exception ex)
        {
            throw new Exception("Error", ex);
        }
    }
}

