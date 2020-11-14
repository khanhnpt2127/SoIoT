using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SoIoT.Application.Common.Interfaces;
using SoIoT.Domain.Entities;

namespace SoIoT.Application.Devices.Commands.CreateDeviceItem
{
    public class CreateDeviceItemCommand : IRequest<string>
    {
        public string Name { get; set; }

        public double ValueStartFrom { get; set; }

        public double ValueEndTo { get; set; }
    }


    public class CreateDeviceItemCommandHandler : IRequestHandler<CreateDeviceItemCommand, string>
    {
        private readonly IApplicationDbContext _context;

        public CreateDeviceItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateDeviceItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new Sensor
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                ValueStartFrom = request.ValueStartFrom,
                ValueEndTo = request.ValueEndTo
            };


            _context.Devices.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
