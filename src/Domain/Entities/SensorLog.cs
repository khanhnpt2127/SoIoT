using SoIoT.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoIoT.Domain.Entities
{
    public class SensorLog : AuditableEntity
    {
        public int Id { get; set; }

        public double Value { get; set; }

        public Sensor Sensor { get; set; }
    }
}
