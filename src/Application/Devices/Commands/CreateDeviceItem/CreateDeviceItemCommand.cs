using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SoIoT.Application.Common.Exceptions;
using SoIoT.Application.Common.Interfaces;
using SoIoT.Application.DeviceThingDesc.Commands;
using SoIoT.Application.DeviceUnit.Command;
using SoIoT.Application.DeviceUnit.Queries;
using SoIoT.Domain.Entities;
using SoIoT.Domain.Enums;

namespace SoIoT.Application.Devices.Commands.CreateDeviceItem
{
    public class CreateDeviceItemCommand : IRequest<string>
    {
        public string Name { get; set; }

        public int ThingsDescId { get; set; }
        
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
            var thingsDesc = _context.ThingsDescs.Any(x => x.Id.Equals(request.ThingsDescId));
            if (!thingsDesc)
                throw new NotFoundException(nameof(ThingsDesc), request.ThingsDescId);

            var entity = new Sensor
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
            };

            
            var deviceThingsDescId = _mediator.Send(new CreateDeviceThingsDescCommand() { DeviceId = entity.Id, DeviceName =request.Name, ThingsDescId = request.ThingsDescId}, cancellationToken);

            entity.DeviceThingsDescId = await deviceThingsDescId;
            
            await _context.Devices.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
