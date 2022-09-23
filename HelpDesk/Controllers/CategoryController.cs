using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.API.Controllers;

[Route("api/category")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet] //GET ALL - Pobieranie wszystkich kategorii
    public ActionResult<IEnumerable<CategoryDto>> GetAll()
    {
        var categories = _categoryService.GetAll();

        return Ok(categories);
    }

    [HttpGet("{id}")] //GET - Pobranie pojedynczej kategorii
    public ActionResult<CategoryDto> GetById([FromRoute] int id)
    {
        var category = _categoryService.GetById(id);

        if (category is null) return NotFound();

        return Ok(category);
    }

    [HttpPost] //POST - Dodawanie kategorii
    public ActionResult Create([FromBody] CreateCategoryDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var id = _categoryService.Create(dto);

        return Created($"/api/category/{id}", null);
    }

    [HttpPut("{id}")] //PUT - Modyfikowanie kategorii,  rozróżnieniem nazwa/opis.
    public ActionResult Update([FromBody] CreateCategoryDto dto, [FromRoute] int id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var isUpdated = _categoryService.Update(id, dto);

        if (!isUpdated) return NotFound();

        return Ok();
    }

    [HttpDelete("{id}")] //DELETE - Usuwanie kategorii.
    public ActionResult Delete([FromRoute] int id)
    {
        var isDeleted = _categoryService.Delete(id);

        if (isDeleted) return NotFound();

        return NoContent();
    }
}