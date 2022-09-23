using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.API.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet] //GET ALL - Pobieranie wszystkich roli
        public ActionResult<IEnumerable<RoleDto>> GetAll()
        {
            var roles = _roleService.GetAll();

            return Ok(roles);
        }

        [HttpGet("{id}")] //GET - Pobranie pojedynczej roli
        public ActionResult<RoleDto> GetById([FromRoute] int id)
        {
            var role = _roleService.GetById(id);

            if (role is null) return NotFound();

            return Ok(role);
        }

        [HttpPost] //POST - Dodawanie roli
        public ActionResult Create([FromBody] CreateRoleDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var id = _roleService.Create(dto);

            return Created($"/api/role/{id}", null);
        }

        [HttpPut("{id}")] //PUT - Modyfikowanie roli,  rozróżnieniem nazwa/opis.
        public ActionResult Update([FromBody] CreateRoleDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var isUpdated = _roleService.Update(id, dto);

            if (!isUpdated) return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")] //DELETE - Usuwanie roli.
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _roleService.Delete(id);

            if (isDeleted) return NotFound();

            return NoContent();
        }
    }
}
