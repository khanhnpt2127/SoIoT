using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SoIoT.Application.Common.Interfaces;
using SoIoT.Domain.Entities;

namespace SoIoT.Application.DeviceLogs.Commands
{
    public class CreateDeviceLogsCommand : IRequest<int>
    {
        public int Id { get; set; }

        public double? Value { get; set; }

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
            double startValue;
            double endValue;
            if (_context.SensorLogs.Any(x => x.Sensor.Id == request.Sensor.Id))
            {
                var lastValue = _context.SensorLogs
                    .Where(s => s.Sensor.Id == request.Sensor.Id).OrderByDescending(s => s.Created).First();

                var delta = lastValue.Created - _dateTime.Now;
                int deltaIncrease;
                if (delta.TotalHours < 5)
                    deltaIncrease = 1;
                // ReSharper disable once ComplexConditionExpression
                else if (delta.TotalHours > 5 && delta.TotalHours < 10)
                    deltaIncrease = 2;
                else
                    deltaIncrease = 3;


                startValue = lastValue.Value - deltaIncrease > request.Sensor.ValueStartFrom
                    ? lastValue.Value - deltaIncrease
                    : request.Sensor.ValueStartFrom;

                endValue = lastValue.Value + deltaIncrease < request.Sensor.ValueEndTo
                    ? lastValue.Value + deltaIncrease
                    : request.Sensor.ValueEndTo;
            }
            else
            {
                startValue = request.Sensor.ValueStartFrom;
                endValue = request.Sensor.ValueEndTo;
            }

            SensorLog entity;
            if (request.Value != null)
                entity = new SensorLog
                {
                    Value = request.Value.Value,
                };
            else
                entity = new SensorLog
                {
                    Value = _randomService.RandomNumberBetween(startValue, endValue)
                };

            var device = await _context.Devices.FindAsync(request.Sensor.Id);
            device.SensorLogs.Add(entity);

            await _context.SaveChangesAsync(cancellationToken); 

            return entity.Id;
        }
    }
}
