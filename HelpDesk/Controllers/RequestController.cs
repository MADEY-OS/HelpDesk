using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.API.Controllers;

[Route("api/request")]
public class RequestController : ControllerBase
{
    private readonly IRequestService _requestService;

    public RequestController(IRequestService requestService)
    {
        _requestService = requestService;
    }

    //GET ALL - Pobieranie wszystkich requestów.
    [HttpGet]
    public ActionResult<IEnumerable<RequestDto>> GetAll()
    {
        var requestsDtos = _requestService.GetAll();
        return Ok(requestsDtos);
    }
}