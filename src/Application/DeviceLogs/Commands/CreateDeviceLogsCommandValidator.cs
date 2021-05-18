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
            RuleFor(v => v.Value).NotEmpty().WithMessage("should provide a value");
            RuleFor(v => v.Sensor).NotNull().WithMessage("should provide device object");
        }
    }
}
