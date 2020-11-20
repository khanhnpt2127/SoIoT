using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SoIoT.Application.DeviceUnit.Command;
using SoIoT.Application.Common.Exceptions;
using SoIoT.Domain.Entities;

namespace SoIoT.Application.IntegrationTests.DeviceUnit.Command
{
    using static Testing;
    public class CreateSensorUnitTest : TestBase
    {
        [Test]
        public void ShouldRequiredMinimumFields()
        {
            var command = new CreateDeviceUnitCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateDeviceUnit()
        {
            var userId = await RunAsDefaultUserAsync();
            var command = new CreateDeviceUnitCommand()
            {
                Name = "Celcius Temparature",
                UnitString= "°C"
            };

            var deviceUnit = await SendAsync(command);

            var item = await FindAsync<SensorUnit>(deviceUnit.Id);

            item.Should().NotBeNull();
            item.Id.Should().Be(deviceUnit.Id);
            item.Name.Should().Be("Celcius Temparature");
            item.CreatedBy.Should().Be(userId);
            item.LastModifiedBy.Should().BeNull();
            item.LastModified.Should().BeNull();
        }
    }
}
