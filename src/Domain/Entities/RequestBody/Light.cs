using System;
using System.Collections.Generic;
using System.Text;

namespace SoIoT.Domain.Entities.RequestBody
{
    public class HueLightPhillips 
    {
        public bool on { get; set; }

        public int bri { get; set; }

        public string alert { get; set; }

        public int transisiontime { get; set; }

        public int bri_inc { get; set; }
    }
}
