using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoIoT.Application.DeviceLogs.Queries
{
    public class DeviceLogsVm
    {
        public DeviceInfoDto Device { get; set; }

        public IList<SensorLogsDto> Data { get; set; }
    }


    public class DeviceSingleLogsVm
    {
        public DeviceInfoDto Device { get; set; }

        public SensorLogsDto Data { get; set; }

    }


}
