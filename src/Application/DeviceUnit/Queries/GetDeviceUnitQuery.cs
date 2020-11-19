using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SoIoT.Application.Common.Interfaces;
using SoIoT.Application.DeviceUnit.Command;

namespace SoIoT.Application.DeviceUnit.Queries
{
    public class GetDeviceUnitQuery : IRequest<DeviceUnitVm> 
    {
        public string DeviceUnitName { get; set; }
    }


    public class GetDeviceUnitHandler : IRequestHandler<GetDeviceUnitQuery, DeviceUnitVm>
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetDeviceUnitHandler(IApplicationDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }


        public async Task<DeviceUnitVm> Handle(GetDeviceUnitQuery request, CancellationToken cancellationToken)
        {
            var sensorUnit = _context.SensorUnits.FirstOrDefault(x => x.Name == request.DeviceUnitName);
            if (sensorUnit == null)
                await _mediator.Send(new CreateDeviceUnitCommand { });

            return new DeviceUnitVm
            {

            };
        }
    }
}
