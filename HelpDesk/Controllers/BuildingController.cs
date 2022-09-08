using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.API.Controllers;

[Route("api/building")]
public class BuildingController : ControllerBase
{
    private readonly IBuildingService _buildingService;

    public BuildingController(IBuildingService buildingService)
    {
        _buildingService = buildingService;
    }

   
    [HttpGet]    //GET ALL - Pobieranie wszystkich budynków.
    public ActionResult<IEnumerable<BuildingDto>> GetAll()
    {
        var buildingsDtos = _buildingService.GetAll();
        return Ok(buildingsDtos);
    }

    [HttpGet("{id}")]  //GET - Pobranie pojedynczego budynku
    public ActionResult<BuildingDto> GetById([FromRoute] int id)
    {
        var building = _buildingService.GetById(id);

        if (building is null) return NotFound();

        return Ok(building);
    }

    [HttpPost] //POST - Dodawanie budynku
    public ActionResult Create([FromBody] CreateBuildingDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var id = _buildingService.Create(dto);

        return Created($"/api/building/{id}", null);
    }

    [HttpPut("{id}")] //PUT - Modyfikowanie budynku,  rozróżnieniem nazwa/opis.
    public ActionResult Update([FromBody] CreateBuildingDto dto, [FromRoute] int id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var isUpdated = _buildingService.Update(id, dto);

        if (!isUpdated) return NotFound();

        return Ok();
    }

    [HttpDelete("{id}")] //DELETE - Usuwanie budynku.
    public ActionResult Delete([FromRoute] int id)
    {
        var isDeleted = _buildingService.Delete(id);

        if (isDeleted) return NotFound();

        return NoContent();
    }
}