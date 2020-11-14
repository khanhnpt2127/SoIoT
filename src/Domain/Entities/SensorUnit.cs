using System;
using System.Collections.Generic;
using System.Text;

namespace SoIoT.Domain.Entities
{
    public class SensorUnit
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Sensor Sensor { get; set; }
    }
}
