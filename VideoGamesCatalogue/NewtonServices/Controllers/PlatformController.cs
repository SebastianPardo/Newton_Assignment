using Microsoft.AspNetCore.Mvc;
using NewtonServices.Bussines.Interfaces;
using NewtonServices.Models.ApiModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewtonServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        IPlatformsService _platformsService;
        public PlatformController(IPlatformsService platformsService)
        {
            _platformsService = platformsService;
        }
        // GET: api/<PlatformController>
        [HttpGet]
        public ActionResult<IEnumerable<Platform>> Get()
        {
            var platforms = _platformsService.GetAll().Select(p => new Platform(p));
            if(platforms == null) {
                return NotFound();
            }
            return Ok(platforms);
        }
    }
}
