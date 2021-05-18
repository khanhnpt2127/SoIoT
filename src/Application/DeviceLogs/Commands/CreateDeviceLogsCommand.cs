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

        private readonly IRandomService _randomService;
        private readonly IDateTime _dateTime;
        public CreateDeviceLogsCommandHandler(IApplicationDbContext context, IRandomService randomService, IDateTime dateTime)
        {
            _context = context;
            _randomService = randomService;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(CreateDeviceLogsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SensorLogs.AddAsync(new SensorLog {Sensor = request.Sensor, Value = request.Value}, cancellationToken);

            return entity.Entity.Id;
        }
    }
}
