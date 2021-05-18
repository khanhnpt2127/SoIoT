using System;
using System.Collections.Generic;
using System.Text;
using SoIoT.Application.Common.Mappings;
using SoIoT.Domain.Entities;

namespace SoIoT.Application.DeviceThingDesc.Queries
{
    public class DeviceThingsDescDto : IMapFrom<DeviceThingsDesc>
    {
        public string Id { get; set; }

        public string DeviceId { get; set; }

        public string Value { get; set; }
    }
}
