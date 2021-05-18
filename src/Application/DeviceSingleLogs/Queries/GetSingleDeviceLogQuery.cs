using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SoIoT.Application.Common.Interfaces;
using SoIoT.Application.DeviceLogs.Commands;
using SoIoT.Application.DeviceLogs.Queries;
using SoIoT.Domain.Entities.RequestBody;
using SoIoT.Domain.Enums;

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
            //TODO: if first time => init 
            var isFirstTime = _context.SensorLogs.Any(x => x.Sensor.Id == request.SensorId);
            if (!isFirstTime)
            {

                //TODO: get type
                var deviceType = _context.Devices.FirstOrDefault(x => x.Id == request.SensorId);

                StringBuilder valueSb = new StringBuilder();
                if (deviceType != null)
                    switch (deviceType.Type)
                    {
                        case Domain.Enums.ESensorType.HueDaySensor:
                            var hueDaylightSensor = new HueDaylightSensor
                                {daylight = false, lastupdated = DateTime.Now.ToString(CultureInfo.InvariantCulture)};
                            valueSb.Append(JsonConvert.SerializeObject(hueDaylightSensor));
                            break;
                        case ESensorType.Default:
                            valueSb.Append(string.Empty);
                            break;
                        case ESensorType.HueWhiteLamp:
                            var hueWhiteLamp = new HueWhiteLamp
                            {
                                @on = false, alert = "none", bri = 100, bri_inc = 100, transisiontime = 10
                            };
                            valueSb.Append(JsonConvert.SerializeObject(hueWhiteLamp));
                            break;
                        default:
                            valueSb.Append(string.Empty);
                            break;
                    }

                var createDeviceLogCommand = new CreateDeviceLogsCommand
                {
                    Sensor = _context.Devices.FirstOrDefault(x => x.Id == request.SensorId),
                    Value = valueSb.ToString()
                };
                await _mediator.Send(createDeviceLogCommand, cancellationToken);
            }

            var sensor = _context.Devices.FirstOrDefault(x => x.Id == request.SensorId);
            var sensorLogs = _context.SensorLogs.Where(x => x.Sensor.Id == sensor.Id).ToList();
            return new DeviceSingleLogsVm
            {
                Device = new DeviceInfoDto
                {
                    Id = request.SensorId,
                    DeviceName = sensor?.Name
                },
                Data = _mapper.Map<SensorLogsDto>(sensorLogs.Last())
            };


        }
    }

}
