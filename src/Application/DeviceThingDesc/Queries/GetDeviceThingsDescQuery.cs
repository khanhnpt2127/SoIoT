using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SoIoT.Application.Common.Interfaces;

namespace SoIoT.Application.DeviceThingDesc.Queries
{
    public class GetDeviceThingsDescQuery : IRequest<DeviceThingsDescVm>
    {
        public string DeviceId { get; set; }
    }
    
    public class GetDeviceThingsDescHandler : IRequestHandler<GetDeviceThingsDescQuery, DeviceThingsDescVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDeviceThingsDescHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public async Task<DeviceThingsDescVm> Handle(GetDeviceThingsDescQuery request, CancellationToken cancellationToken)
        {


            var res = await _context.DeviceThingsDescs.FirstOrDefaultAsync(x => x.Sensor.Id == request.DeviceId,
                cancellationToken);



            return new DeviceThingsDescVm
            {
                DeviceThingsDescDto = _mapper.Map<DeviceThingsDescDto>(res)
            };
        }
    }
}
