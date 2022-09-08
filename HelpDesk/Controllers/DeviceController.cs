using System.IO.Compression;
using System.Runtime.InteropServices.ComTypes;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.API.Controllers
{
    [Route("api/device")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet("{id}")]
        public ActionResult<DeviceDto> GetById([FromRoute] int id)
        {
            var device = _deviceService.GetById(id);

            if (device is null) return NotFound();

            return Ok(device);
        }

        [HttpGet]
        public ActionResult<IEnumerable<DeviceDto>> GetAll()
        {
            var devices = _deviceService.GetAll();

            return Ok(devices);
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateDeviceDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var id = _deviceService.Create(dto);

            return Created($"/api/device/{id}", null);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] CreateDeviceDto dto, [FromRoute] int id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var isUpdated = _deviceService.Update(id, dto);

            if (!isUpdated) return NotFound();

            return Ok();    
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var isDeleted = _deviceService.Delete(id);

            if(isDeleted) return NotFound();

            return Ok();
        }
    }
}
