using System;
using System.Collections.Generic;
using System.Text;
using SoIoT.Domain.Common;
using SoIoT.Domain.Enums;

namespace SoIoT.Domain.Entities
{
    public class DeviceThingsDesc : AuditableEntity
    {
        public string Id { get; set; }

        public string Value { get; set; }

        public ESensorType Type { get; set; }

        public virtual Sensor Sensor { get; set; }
    }
}
