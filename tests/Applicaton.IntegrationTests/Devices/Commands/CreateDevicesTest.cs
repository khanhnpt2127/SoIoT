using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SoIoT.Application.Common.Exceptions;
using SoIoT.Application.Devices.Commands.CreateDeviceItem;
using SoIoT.Domain.Entities;

namespace SoIoT.Application.IntegrationTests.Devices.Commands
{

    using static Testing;
    public class CreateDevicesTests : TestBase
    {
        [Test]
        public void ShouldRequiredMinimumFields()
        {
            var command = new CreateDeviceItemCommand();


            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }


        [Test]
        public async Task ShouldCreateDeviceItem()
        {

            var userId = await RunAsDefaultUserAsync();

            var device = new CreateDeviceItemCommand
            {
                Id = Guid.NewGuid().ToString(),
                Name = "New Devices",
                ValueStartFrom = 10,
                ValueEndTo = 11
            };


            var deviceId = await SendAsync(device);

            var item = await FindAsync<Sensor>(deviceId);


            item.Should().NotBeNull();
            item.Name.Should().Be(device.Name);
            item.Id.Should().Be(device.Id);
            item.CreatedBy.Should().Be(userId);
            item.LastModifiedBy.Should().BeNull();
            item.LastModified.Should().BeNull();
        }

        [Test]
        public void ShouldThrownExceptionForLessThanEndTo()
        {

            var command = new CreateDeviceItemCommand
            {
                Id = Guid.NewGuid().ToString(),
                Name = "New Devices",
                ValueStartFrom = 12,
                ValueEndTo = 11
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();

        }
    }
}
