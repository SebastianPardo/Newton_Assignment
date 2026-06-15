using Microsoft.AspNetCore.Mvc;
using NewtonServices.Bussines.Interfaces;
using NewtonServices.Models.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewtonServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        IGenresService _genresService;
        public GenreController(IGenresService genresService)
        {
            _genresService = genresService;
        }
        // GET: api/<PlatformController>
        [HttpGet]
        public ActionResult<IEnumerable<Genre>> Get()
        {
            var genres = _genresService.GetAll();
            if (genres == null)
            {
                return NotFound();
            }
            return Ok(genres);
        }
    }
}
