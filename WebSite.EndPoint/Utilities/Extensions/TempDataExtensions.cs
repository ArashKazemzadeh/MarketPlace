
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Extensions
{
    public static class TempDataExtensions
    {
        public static void SetDateAppSettingValues(this ITempDataDictionary tempData, IConfiguration configuration)
        {
            tempData["Years"] = configuration.GetSection("Years").Get<string[]>();
            tempData["Months"] = configuration.GetSection("Months").Get<string[]>();
            tempData["Days"] = configuration.GetSection("Days").Get<string[]>();
            tempData["Hours"] = configuration.GetSection("Hours").Get<string[]>();
            tempData["Minutes"] = configuration.GetSection("Minutes").Get<string[]>();
            tempData.Keep();
        }
    }
}
