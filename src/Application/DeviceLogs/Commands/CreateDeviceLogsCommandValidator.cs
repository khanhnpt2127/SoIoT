using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoIoT.Application.DeviceLogs.Commands
{
    public class CreateDeviceLogsCommandValidator : AbstractValidator<CreateDeviceLogsCommand>
    {
        public CreateDeviceLogsCommandValidator()
        {
            RuleFor(v => v.Value).GreaterThanOrEqualTo(s => s.Sensor.ValueStartFrom).WithMessage("fail greater than");
            RuleFor(v => v.Value).LessThanOrEqualTo(s => s.Sensor.ValueEndTo).WithMessage("fail less than");
            RuleFor(v => v.Sensor).NotNull();
        }
    }
}
