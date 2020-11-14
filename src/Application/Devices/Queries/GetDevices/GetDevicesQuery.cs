using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SoIoT.Application.Common.Interfaces;

namespace SoIoT.Application.Devices.Queries.GetDevices
{
    public class GetDevicesQuery : IRequest<DevicesVm>
    {

    }


    public class GetDevicesHandler : IRequestHandler<GetDevicesQuery, DevicesVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDevicesHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        async Task<DevicesVm> IRequestHandler<GetDevicesQuery, DevicesVm>.Handle(GetDevicesQuery request, CancellationToken cancellationToken)
        {
            return new DevicesVm
            {
                Lists = _context.Devices.ProjectTo<DevicesDto>(_mapper.ConfigurationProvider).ToList()
            };
        }
    }
}
