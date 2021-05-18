using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SoIoT.Application.Common.Interfaces;

namespace SoIoT.Application.ThingsDesc.Queries
{
    public class GetThingsDescQuery : IRequest<ThingsDescVm>
    {

    }

    public class GetThingsDescHandler : IRequestHandler<GetThingsDescQuery, ThingsDescVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetThingsDescHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public async Task<ThingsDescVm> Handle(GetThingsDescQuery request, CancellationToken cancellationToken)
        {
            return new ThingsDescVm()
            {
                ThingsDescDtos = await _context.ThingsDescs.ProjectTo<ThingsDescDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
