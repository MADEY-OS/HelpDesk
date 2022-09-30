using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.API.Controllers;

[Route("api/request")]
[ApiController]
public class RequestController : ControllerBase
{
    private readonly IRequestService _requestService;

    public RequestController(IRequestService requestService)
    {
        _requestService = requestService;
    }

    //GET ALL - Pobieranie wszystkich requestów.
    [HttpGet]
    public ActionResult<IEnumerable<DetailedRequestDto>> GetAll()
    {
        var requestsDtos = _requestService.GetAll();
        return Ok(requestsDtos);
    }

    [HttpGet("{id}")] //GET - Pobranie pojedynczego requesta
    public ActionResult<DetailedRequestDto> GetById([FromRoute] int id)
    {
        var request = _requestService.GetById(id);

        if (request is null) return NotFound();

        return Ok(request);
    }

    [HttpPost] //POST - Dodawanie requesta
    public async Task<IActionResult> Create([FromBody] CreateRequestDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var id = _requestService.Create(dto);

        return Created($"/api/request/{id}", null);
    }

    [HttpPut("{id}")] //PUT - Modyfikowanie requesta,  rozróżnieniem nazwa/opis.
    public ActionResult Update([FromBody] CreateRequestDto dto, [FromRoute] int id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var isUpdated = _requestService.Update(id, dto);

        if (!isUpdated) return NotFound();

        return Ok();
    }

    [HttpDelete("{id}")] //DELETE - Usuwanie requesta.
    public ActionResult Delete([FromRoute] int id)
    {
        var isDeleted = _requestService.Delete(id);

        if (isDeleted) return NotFound();

        return NoContent();
    }
}