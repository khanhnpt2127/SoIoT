using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoIoT.Application.DeviceLogs.Queries;
using SoIoT.Application.Devices.Commands.CreateDeviceItem;
using SoIoT.Application.Devices.Queries.GetDevices;
using SoIoT.Application.TodoItems.Commands.CreateTodoItem;
using SoIoT.Domain.Entities;

namespace SoIoT.WebUI.Controllers
{
    public class DevicesController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateDeviceItemCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<DevicesVm>> Get()
        {
            return await Mediator.Send(new GetDevicesQuery());
        }


        [HttpGet("{sensorId}")]
        public async Task<ActionResult<DeviceLogsVm>> GetDeviceLog(string sensorId)
        {
            return await Mediator.Send(new GetDeviceLogQuery { SensorId = sensorId});
        }

    }
}
