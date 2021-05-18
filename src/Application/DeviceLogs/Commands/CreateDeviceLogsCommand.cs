using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using SoIoT.Application.Common.Interfaces;
using SoIoT.Domain.Entities;
using SoIoT.Domain.Entities.RequestBody;

namespace SoIoT.Application.DeviceLogs.Commands
{
    public class CreateDeviceLogsCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public Sensor Sensor{ get; set; }
    }


    public class CreateDeviceLogsCommandHandler : IRequestHandler<CreateDeviceLogsCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public CreateDeviceLogsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateDeviceLogsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SensorLogs.AddAsync(new SensorLog {Sensor = request.Sensor, Value = request.Value}, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Entity.Id;
        }
    }
}
