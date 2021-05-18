using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SoIoT.Application.Common.Interfaces;
using SoIoT.Domain.Entities;
using SoIoT.Domain.Enums;

namespace SoIoT.Application.DeviceThingDesc.Commands
{
    public class CreateDeviceThingsDescCommand : IRequest<string>
    {
        public string DeviceId { get; set; }

        public string DeviceName { get; set; }

        public string BaseUrl { get; set; }


        public string ThingsDescName { get; set; }
    }


    public class CreateDeviceThingsDescCommandHandler : IRequestHandler<CreateDeviceThingsDescCommand, string>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMediator _mediator;

        public CreateDeviceThingsDescCommandHandler(IApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }


        public async Task<string> Handle(CreateDeviceThingsDescCommand request, CancellationToken cancellationToken)
        {
            var thingsDescTemplate = _context.ThingsDescs.FirstOrDefault(x => x.Name.Equals(request.ThingsDescName));
            if (thingsDescTemplate == null) return "exception";
            var thingDescString = thingsDescTemplate.Value.ToString();

            if (thingsDescTemplate.Value.Contains("{nameofdev}"))
                thingDescString = thingDescString.Replace("{nameofdev}", request.DeviceName);


            if (thingsDescTemplate.Value.Contains("{devid}"))
                thingDescString = thingDescString.Replace("{devid}", request.DeviceId);

            if (thingsDescTemplate.Value.Contains("{baseUrl}"))
                thingDescString = thingDescString.Replace("{baseUrl", request.BaseUrl);

            var entity = new DeviceThingsDesc
            {
                Id = Guid.NewGuid().ToString(),
                Value = thingDescString,
            };

            await _context.DeviceThingsDescs.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }

}
