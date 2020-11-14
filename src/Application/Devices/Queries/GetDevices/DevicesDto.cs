using SoIoT.Application.Common.Mappings;
using SoIoT.Domain.Entities;

namespace SoIoT.Application.Devices.Queries.GetDevices
{
    public class DevicesDto : IMapFrom<Sensor>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double ValueStartFrom { get; set; }

        public double ValueEndTo { get; set; }
    }
}