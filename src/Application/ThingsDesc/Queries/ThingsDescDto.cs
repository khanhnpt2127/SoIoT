using System;
using System.Collections.Generic;
using System.Text;
using SoIoT.Application.Common.Mappings;

namespace SoIoT.Application.ThingsDesc.Queries
{
    public class ThingsDescDto : IMapFrom<Domain.Entities.ThingsDesc>
    {
        public string Id { get; set; }


        public string Value { get; set; }
    }
}
