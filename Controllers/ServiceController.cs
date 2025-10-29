using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DapperASPNetCore.Contracts;

namespace DapperASPNetCore.Controllers {
[Route("api/services")]
[ApiController]
public class ServicesController : ControllerBase
{
  private readonly IServiceRepository _serviceRepo;

  public ServicesController(IServiceRepository serviceRepo) =>  _serviceRepo = serviceRepo;

  [HttpGet]
  public async Task<IActionResult> GetServices()
    {
      try
      {
        var services = await _serviceRepo.GetServices();
        return Ok(services);
      }
      catch (Exception ex)
      {
        //log error
        return StatusCode(500, ex.Message);
      }
    }
}
}
