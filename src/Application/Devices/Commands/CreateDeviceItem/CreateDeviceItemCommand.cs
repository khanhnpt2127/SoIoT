using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SoIoT.Application.Common.Interfaces;
using SoIoT.Application.DeviceUnit.Command;
using SoIoT.Application.DeviceUnit.Queries;
using SoIoT.Domain.Entities;
using SoIoT.Domain.Enums;

namespace SoIoT.Application.Devices.Commands.CreateDeviceItem
{
    public class CreateDeviceItemCommand : IRequest<string>
    {
        public string Name { get; set; }

        public double ValueStartFrom { get; set; }

        public double ValueEndTo { get; set; }

        public string SensorUnitName { get; set; }

        public string SensorUnitString { get; set; }

        public ESensorType ESensorType { get; set; }
    }


    public class CreateDeviceItemCommandHandler : IRequestHandler<CreateDeviceItemCommand, string>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMediator _mediator;
        public CreateDeviceItemCommandHandler(IApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<string> Handle(CreateDeviceItemCommand request, CancellationToken cancellationToken)
        {
            var sensorUnit = _mediator.Send(new GetDeviceUnitQuery { DeviceUnitName = request.SensorUnitName, DeviceUnitString = request.SensorUnitString});
            

            var entity = new Sensor
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                ValueStartFrom = request.ValueStartFrom,
                ValueEndTo = request.ValueEndTo,
                SensorUnit = sensorUnit.Result,
                SensorType = request.ESensorType
            };


            _context.Devices.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
