using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("players")]
public class PlayersController(IPlayerService service) : Controller
{
    private readonly IPlayerService _service = service;

    [HttpGet]
    public IActionResult Index()
    {
        try
        {
            var result = _service.GetPLayers();
            return Ok(result.Data);
        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }       
    }

    [HttpGet("{id}")]
    public IActionResult Details(int id)
    {
        try
        {
            var result = _service.GetPlayerById(id);

            if (result.IsFailure)
            {
                return BadRequest(result.Errors.Description);
            }

            return Ok(result.Data);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("/stats")]
    public IActionResult GetStats()
    {
        try
        {
            var result = _service.GetStats();

            if (result.IsFailure)
            {
                return BadRequest(result.Errors.Description);
            }

            return Ok(result.Data);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    } 
}
