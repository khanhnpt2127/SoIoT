using SoIoT.Application.Common.Mappings;
using SoIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoIoT.Application.DeviceLogs.Queries
{
    public class SensorLogsDto : IMapFrom<SensorLog>
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public DateTime Created { get; set; }
    }
}
