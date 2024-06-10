using Microsoft.AspNetCore.Mvc;
using Test2_Mock.Services;

namespace Test2_Mock.Controllers;

[ApiController]
public class ApplicationController : ControllerBase
{
    private IAppService _appService;

    public ApplicationController(IAppService appService)
    {
        _appService= appService;
    }

    [HttpGet("/reservations/{idCustomer:int}")]
    public async Task<IActionResult> GetReservations(int idCustomer)
    {
        
        var result = await _appService.GetReservations(idCustomer);
        
        return Ok(result);
    }

    [HttpGet("clients")]
    public IActionResult GetClients()
    {
        return Ok(_appService.GetClients());
    }
}   