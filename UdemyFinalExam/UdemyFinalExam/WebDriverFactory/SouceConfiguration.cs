using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyFinalExam;

namespace UdemyFinalExam.WebDriverFactory
{
    public class SauceConfiguration
    {
        public string OS;
        public string Browser { get; set; }
        public string Version { get; set; }
        public string DeviceName { get; set; }
        public string DeviceOrientation { get; set; }
        public string TestCaseName { get; set; }
    }
}
