using System;
using System.Collections.Generic;
using System.Text;

namespace SoIoT.Application.DeviceLogs.Queries
{
    public class DeviceInfoDto
    {
        public string Id { get; set; }

        public string DeviceName { get; set; }

        public string DeviceType { get; set; }

        public string DeviceUnit { get; set; }
    }
}
