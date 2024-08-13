namespace prjZapperTests;
using prjZapper.Utility;

[TestClass]
public class SettingsUtilTests
{
    [TestMethod]
    public void CheckUtilitySettings_ValidSetting_ReturnsFalse()
    {
        // Arrange
        string settings = "00000000";
        int? numberOfSetting = 7;

        // Act
        bool result = SettingsUtil.checkUtilitySettings(settings, numberOfSetting);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void CheckUtilitySettings_ValidSetting_ReturnsTrue()
    {
        // Arrange
        string settings = "00000010";
        int? numberOfSetting = 7;

        // Act
        bool result = SettingsUtil.checkUtilitySettings(settings, numberOfSetting);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void CheckUtilitySettings_Valid1Setting_ReturnsTrue()
    {
        // Arrange
        string settings = "11111111";
        int? numberOfSetting = 7;

        // Act
        bool result = SettingsUtil.checkUtilitySettings(settings, numberOfSetting);

        // Assert
        Assert.IsTrue(result);
    }
}
