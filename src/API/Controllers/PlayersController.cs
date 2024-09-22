using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("players")]
public class PlayersController(IPlayerService service) : Controller
{
    private readonly IPlayerService _service = service;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            var result = await _service.GetPLayers();
            return Ok(result);
        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }       
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Details(int id)
    {
        try
        {
            var result = await _service.GetPlayerById(id);

            if (result.IsFailure)
            {
                return BadRequest(result.Errors.Description);
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("/stats")]
    public async Task<IActionResult> GetStats()
    {
        try
        {
            var result = await _service.GetStats();

            if (result.IsFailure)
            {
                return BadRequest(result.Errors.Description);
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    } 
}
