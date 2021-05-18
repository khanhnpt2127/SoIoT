using System;
using System.Collections.Generic;
using System.Text;

namespace SoIoT.Domain.Entities.RequestBody
{
    public class HueDaylightSensor
    {
        public bool daylight { get; set; }
        public string lastupdated { get; set; }
    }
}
