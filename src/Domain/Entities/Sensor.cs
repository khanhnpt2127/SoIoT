using SoIoT.Domain.Common;
using SoIoT.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoIoT.Domain.Entities
{
    public class Sensor : AuditableEntity
    {
        public Sensor()
        {
            SensorLogs = new HashSet<SensorLog>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public ESensorType SensorType { get; set; }

        public int SensorUnitId { get; set; }
        public virtual SensorUnit SensorUnit { get; set; }

        public ICollection<SensorLog> SensorLogs { get; private set; }
        public string DeviceThingsDescId { get; set; }
        public virtual DeviceThingsDesc DeviceThingsDesc { get; set; }

    }
}
