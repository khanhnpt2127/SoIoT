using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SoIoT.Application.Common.Exceptions;
using SoIoT.Application.Devices.Commands.CreateDeviceItem;
using SoIoT.Application.ThingsDesc.Commands;
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

            var thingsDesc = new CreateThingsDescCommand
            {
                Name= "HUE Dim Light",
                Value= "test"
            }; 

            await SendAsync(thingsDesc);

            var userId = await RunAsDefaultUserAsync();

            var device = new CreateDeviceItemCommand
            {
                Name = "New Devices",
                ThingsDescName = "HUE Dim Light"
            };


            var deviceId = await SendAsync(device);

            var item = await FindAsync<Sensor>(deviceId);


            item.Should().NotBeNull();
            item.Name.Should().Be(device.Name);
            item.CreatedBy.Should().Be(userId);
            item.LastModifiedBy.Should().BeNull();
            item.LastModified.Should().BeNull();
        }

        [Test]
        public void ShouldThrownExceptionForLessThanEndTo()
        {

            var command = new CreateDeviceItemCommand
            {
                Name = "New Devices",
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();

        }
    }
}
