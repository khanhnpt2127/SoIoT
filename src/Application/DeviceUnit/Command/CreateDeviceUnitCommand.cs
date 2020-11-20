using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SoIoT.Application.Common.Interfaces;
using SoIoT.Domain.Entities;

namespace SoIoT.Application.DeviceUnit.Command
{
    public class CreateDeviceUnitCommand : IRequest<SensorUnit>
    {
        public string Name { get; set; }

        public string UnitString { get; set; }
    }


    public class CreateDeviceUnitCommandHandler : IRequestHandler<CreateDeviceUnitCommand, SensorUnit>
    {

        private readonly IApplicationDbContext _context;

        public CreateDeviceUnitCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<SensorUnit> Handle(CreateDeviceUnitCommand request, CancellationToken cancellationToken)
        {
            var sensorUnit = _context.SensorUnits.FirstOrDefault(x => x.Name == request.Name);
            if (sensorUnit == null)
            {
                sensorUnit = new Domain.Entities.SensorUnit
                {
                    Name = request.Name,
                    UnitString = request.UnitString
                };
                await _context.SensorUnits.AddAsync(sensorUnit, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return sensorUnit;
        }
    }
}
