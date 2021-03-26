using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SoIoT.Application.Common.Interfaces;
using SoIoT.Application.DeviceLogs.Commands;
using SoIoT.Domain.Entities;
using System.Security.Cryptography.X509Certificates;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace SoIoT.Application.DeviceLogs.Queries
{
    public class GetDeviceLogQuery : IRequest<DeviceLogsVm>
    {
        public string SensorId { get; set; }
    }


    public class GetDevicesHandler : IRequestHandler<GetDeviceLogQuery, DeviceLogsVm>
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetDevicesHandler(IMapper mapper, IApplicationDbContext context, IMediator mediator)
        {
            _mapper = mapper;
            _context = context;
            _mediator = mediator;
        }

        public async Task<DeviceLogsVm> Handle(GetDeviceLogQuery request, CancellationToken cancellationToken)
        {
            var createDeviceLogCommand = new CreateDeviceLogsCommand
            {
                Sensor = _context.Devices.FirstOrDefault(x => x.Id == request.SensorId) 
            };
            await _mediator.Send(createDeviceLogCommand);


            var data = Queryable.FirstOrDefault(_context.Devices.Include(x=>x.SensorUnit), x=>x.Id == request.SensorId);

            var d = _context.SensorLogs.Where(x => x.Sensor.Id == data.Id).ToList();

            var dt = _mapper.Map<List<SensorLogsDto>>(d);


            return new DeviceLogsVm
            {
                Device = new DeviceInfoDto { 
                    Id = request.SensorId,
                    DeviceType = data?.SensorType.ToString(), 
                    DeviceUnit = data?.SensorUnit?.UnitString,
                    DeviceName = data?.Name
                },                        

                Data = dt 
            };

        }
    }

}
