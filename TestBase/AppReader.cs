using System;
using System.Configuration;

namespace TestFrameworkAPI.TestBase
{
    //-------------------------------------------------------------------------------------//
    //                     Class to read values from the App.config file                   // 
    //-------------------------------------------------------------------------------------//
    public static class AppReader
    {
        public static string GetConfigValue(String key)
        {
            string value = "";

            value =  ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("\n Exception occured when geting value from config \n Check Key : {0}", key);
                //Helper.HaltScript();
            }
            return value;
        }
    }
}
