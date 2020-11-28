using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static TestFrameworkCore.TestBase.TestInitialise;
using System.Diagnostics;
using TestFrameworkAPI.Repo;

namespace TestFrameworkAPI.TestBase
{
    //-------------------------------------------------------------------------------------//
    //                     Class to add any helper methods commonly used                   // 
    //-------------------------------------------------------------------------------------//

    public static class Helper 
    {
        //static IWebDriver driver;
        public static void HaltScript()
        {
            Thread.CurrentThread.Abort();
        }

    }
}
