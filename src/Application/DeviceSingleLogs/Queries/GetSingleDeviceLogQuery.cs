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
using SoIoT.Application.DeviceLogs.Commands;
using SoIoT.Application.DeviceLogs.Queries;

namespace SoIoT.Application.DeviceSingleLogs.Queries
{
    public class GetSingleDeviceLogQuery : IRequest<DeviceSingleLogsVm>
    {
        public string SensorId { get; set; }
    }


    public class GetSingleDeviceLog : IRequestHandler<GetSingleDeviceLogQuery, DeviceSingleLogsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetSingleDeviceLog(IMapper mapper, IApplicationDbContext context, IMediator mediator)
        {
            _mapper = mapper;
            _context = context;
            _mediator = mediator;
        }

        public async Task<DeviceSingleLogsVm> Handle(GetSingleDeviceLogQuery request, CancellationToken cancellationToken)
        {
            var createDeviceLogCommand = new CreateDeviceLogsCommand
            {
                Sensor = _context.Devices.FirstOrDefault(x => x.Id == request.SensorId)
            };
            await _mediator.Send(createDeviceLogCommand);
            var data = _context.Devices.FirstOrDefault(x => x.Id == request.SensorId);
            var d = _context.SensorLogs.Where(x => x.Sensor.Id == data.Id).ToList();

            return new DeviceSingleLogsVm
            {
                Device = new DeviceInfoDto
                {
                    Id = request.SensorId,
                    DeviceType = data?.SensorType.ToString(),
                    DeviceName = data?.Name
                },
                Data = _mapper.Map<SensorLogsDto>(d.Last())
            };


        }
    }

}
