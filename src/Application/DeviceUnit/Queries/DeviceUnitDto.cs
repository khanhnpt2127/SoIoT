using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoIoT.Application.Common.Mappings;
using SoIoT.Domain.Entities;

namespace SoIoT.Application.DeviceUnit.Queries
{
    public class DeviceUnitDto : IMapFrom<SensorUnit>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UnitString { get; set; }
    }
}
