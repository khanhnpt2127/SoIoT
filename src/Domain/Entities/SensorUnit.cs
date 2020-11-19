using SoIoT.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoIoT.Domain.Entities
{
    public class SensorUnit : AuditableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UnitString  { get; set; }

        public Sensor Sensor { get; set; }
    }
}
