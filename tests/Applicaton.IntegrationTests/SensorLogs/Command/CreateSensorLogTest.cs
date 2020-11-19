using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualBasic;
using NUnit.Framework;
using SoIoT.Application.Common.Exceptions;
using SoIoT.Application.DeviceLogs.Commands;
using SoIoT.Application.DeviceLogs.Queries;
using SoIoT.Application.Devices.Commands.CreateDeviceItem;
using SoIoT.Domain.Entities;

namespace SoIoT.Application.IntegrationTests.SensorLogs.Command
{
    using static Testing;
    public class CreateSensorLogTest : TestBase
    {

        [Test]
        public void ShouldRequiredMinimumFields()
        {
            var command = new CreateDeviceLogsCommand();


            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }


        [Test]
        public async Task ShouldThrowValidationException()
        {
            
            var userId = await RunAsDefaultUserAsync();

            var device = new CreateDeviceItemCommand
            {
                Name = "New Devices",
                ValueStartFrom = 10,
                ValueEndTo = 11
            };

            var deviceId = await SendAsync(device);

            var item = await FindAsync<Sensor>(deviceId);


            var command = new CreateDeviceLogsCommand
            {
                Value = 15,
                Sensor = item
            };


            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateSensorLogItem()
        {
            var userId = await RunAsDefaultUserAsync();

            var device = new CreateDeviceItemCommand
            {
                Name = "New Devices",
                ValueStartFrom = 10,
                ValueEndTo = 15
            };

            var deviceId = await SendAsync(device);

            var item = await FindAsync<Sensor>(deviceId);


            var command = new CreateDeviceLogsCommand
            {
                Value = 12,
                Sensor = item
            };

            var sensorLog = await SendAsync(command);

            var sensorItem = await FindAsync<SensorLog>(sensorLog);

            sensorItem.Should().NotBeNull();
            sensorItem.Value.Should().Be(12);
            sensorItem.CreatedBy.Should().Be(userId);
            sensorItem.LastModifiedBy.Should().BeNull();
            sensorItem.LastModified.Should().BeNull();
        }

        [Test]
        public async Task ShouldCreateSensorLogItemValueRandom()
        {
            var userId = await RunAsDefaultUserAsync();

            var device = new CreateDeviceItemCommand
            {
                Name = "New Devices",
                ValueStartFrom = 10,
                ValueEndTo = 15
            };

            var deviceId = await SendAsync(device);

            var item = await FindAsync<Sensor>(deviceId);


            var command = new CreateDeviceLogsCommand
            {
                Sensor = item
            };

            var sensorLog = await SendAsync(command);

            var sensorItem = await FindAsync<SensorLog>(sensorLog);

            sensorItem.Should().NotBeNull();
            sensorItem.Value.Should().BeGreaterThan(10).And.BeLessThan(15);
            sensorItem.CreatedBy.Should().Be(userId);
            sensorItem.LastModifiedBy.Should().BeNull();
            sensorItem.LastModified.Should().BeNull();
        }


        [Test]
        public async Task ShouldRerturnACorrectVM()
        { 
             
            var userId = await RunAsDefaultUserAsync();

            var device = new CreateDeviceItemCommand
            {
                Name = "New Devices",
                ValueStartFrom = 10,
                ValueEndTo = 15
            };

            var deviceId = await SendAsync(device);

            var item = await FindAsync<Sensor>(deviceId);

            var command = new GetDeviceLogQuery() {
                SensorId = item.Id
            };

            var deviceVm = await SendAsync(command);

            deviceVm.Device.Id.Should().Be(item.Id);
            deviceVm.Data.Should().NotBeNull();
            deviceVm.Device.DeviceType.Should().Be("Temparature");
        }


    }
}
