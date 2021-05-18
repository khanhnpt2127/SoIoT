using System;
using System.Collections.Generic;
using System.Text;
using SoIoT.Application.Common.Mappings;

namespace SoIoT.Application.ThingsDesc.Queries
{
    public class ThingsDescDto : IMapFrom<Domain.Entities.ThingsDesc>
    {
        public int Id { get; set; }
    }
}
