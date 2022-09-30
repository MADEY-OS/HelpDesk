using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet] //GET ALL - Pobieranie wszystkich użytkowników
        public async Task<ActionResult<IEnumerable<DetailedUserDto>>> GetAll()
        {
            var users = _userService.GetAll();

            return Ok(users);
        }

        [HttpGet("{id}")] //GET - Pobranie pojedynczego użtkownika
        public async Task<ActionResult<UserDto>> GetById([FromRoute] int id)
        {
            var user = _userService.GetById(id);

            if (user is null) return NotFound();

            return Ok(user);
        }

        [HttpPost] //POST - Dodawanie użytkownika
        public ActionResult Create([FromBody] CreateUserDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var id = _userService.Create(dto);

            return Created($"/api/user/{id}", null);
        }

        [HttpPut("{id}")] //PUT - Modyfikowanie użytkownika,  rozróżnieniem nazwa/opis.
        public ActionResult Update([FromBody] CreateUserDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var isUpdated = _userService.Update(id, dto);

            if (!isUpdated) return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")] //DELETE - Usuwanie użytkownika.
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _userService.Delete(id);

            if (isDeleted) return NotFound();

            return NoContent();
        }

    }
}
