using Microsoft.AspNetCore.Mvc;
using NewtonServices.Bussines.Interfaces;
using NewtonServices.Models.ApiModels;
using EntityVideoGame = NewtonServices.Models.Entities.VideoGame;

namespace NewtonServices.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class CatalogueController : ControllerBase
    {
        IVideoGamesService _videoGamesService;
        IPlatformsService _platformsService;
        IGenresService _genresService;

        public CatalogueController(IVideoGamesService videoGamesService, IPlatformsService platformsService, IGenresService genresService)
        {
            _videoGamesService = videoGamesService;
            _platformsService = platformsService;
            _genresService = genresService;
        }

        //GET: api/<CatalogueController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoGame>>> Get()
        {
            var videoGames = _videoGamesService.GetAllAvailables().Select(e => new VideoGame(e)).ToList();

            if (!videoGames.Any())
                return NotFound();

            return Ok(videoGames);
        }

        //// GET api/<CatalogueController>/5
        [HttpGet("{id}")]
        public ActionResult<EntityVideoGame?> GetById(Guid id)
        {
            EntityVideoGame? videoGame = _videoGamesService.GetById(id);
            if (videoGame == null)
                return NotFound();

            return Ok(videoGame);
        }

        [HttpGet("GetByPlatform/{code}")]
        public async Task<ActionResult<IEnumerable<VideoGame>>> GetByPlatform(string code)
        {
            var platform = _platformsService.GetByCode(code);
            if (platform == null)
                return NotFound();

            var videoGames = _videoGamesService.GetAllByPlatform(code).Select(e => new VideoGame(e));

            if (!videoGames.Any())
                return NotFound();

            return Ok(videoGames);
        }

        [HttpGet("GetByGenre/{code}")]
        public async Task<ActionResult<IEnumerable<VideoGame>>> GetByGenre(string code)
        {
            var genre = _genresService.GetByCode(code);
            if (genre == null)
                return NotFound();

            var videoGames = _videoGamesService.GetAllByGenre(code).Select(e => new VideoGame(e));

            if (!videoGames.Any())
                return NotFound();

            return Ok(videoGames);
        }


        // POST api/<CatalogueController>
        [HttpPost]
        public async Task<ActionResult<EntityVideoGame>> Create(EntityVideoGame videoGame)
        {
            var createdVideoGame = _videoGamesService.Add(videoGame);
            if (createdVideoGame == null)
                return BadRequest();
            return CreatedAtAction(nameof(Get), new { id = createdVideoGame.Id }, createdVideoGame);
        }

        // PUT api/<CatalogueController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Update(Guid id, EntityVideoGame videoGame)
        {
            if (id != videoGame.Id)
                return BadRequest();
            var existingVideoGame = _videoGamesService.GetById(id);
            if (existingVideoGame == null)
                return NotFound();
            var result = _videoGamesService.Update(videoGame);
            if (!result)
                return StatusCode(500, "An error occurred while updating the video game.");
            return Ok(result);
        }

        // DELETE api/<CatalogueController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            var existingVideoGame = _videoGamesService.GetById(id);
            if (existingVideoGame == null)
                return NotFound();
            var result = _videoGamesService.Delete(existingVideoGame);
            if (!result)
                return StatusCode(500, "An error occurred while deleting the video game.");
            return Ok(result);
        }
    }
}
