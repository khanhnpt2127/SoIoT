using System;
using System.Collections.Generic;
using System.Text;
using SoIoT.Domain.Common;

namespace SoIoT.Domain.Entities
{
    public class ThingsDesc : AuditableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

    }
}
