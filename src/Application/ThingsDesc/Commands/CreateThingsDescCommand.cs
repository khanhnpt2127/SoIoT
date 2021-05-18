using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SoIoT.Application.Common.Interfaces;

namespace SoIoT.Application.ThingsDesc.Commands
{
    public class CreateThingsDescCommand : IRequest<string>
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }


    public class CreateThingsDescCommandHandler : IRequestHandler<CreateThingsDescCommand, string>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMediator _mediator;

        public CreateThingsDescCommandHandler(IMediator mediator, IApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<string> Handle(CreateThingsDescCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.ThingsDesc
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Value = request.Value
            };

            await _context.ThingsDescs.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }


}
