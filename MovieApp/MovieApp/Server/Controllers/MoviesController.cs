using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieApp.Server.Services;
using MovieApp.Shared.DTOs;
using System.Threading.Tasks;


namespace MovieApp.Server.Controllers
{

    [Authorize]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IMoviesDbService _dbService;

        public MoviesController(ILogger<MoviesController> logger, IMoviesDbService dbService)
        {
            _logger = logger;
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            return Ok(await _dbService.GetMovies());
        }

        [HttpPut("{idMovie}")]
        public async Task<IActionResult> UpdateMovie(MovieDTO movie, int idMovie)
        {
            bool isUpdated = await _dbService.UpadteMovie(movie, idMovie);
            if (!isUpdated)
                return BadRequest($"The movie with id {idMovie} isn't in database");
            return Ok($"The movie {idMovie} has been updated");
        }

        [HttpPost]
        public async Task<IActionResult> AddNewMovie(MovieDTO movieDTO)
        {
            if (await _dbService.AddMovie(movieDTO))
                return Ok($"MoiveID {movieDTO.Id} movieTitle {movieDTO.Title} has been added");
            return BadRequest($"The movie: {movieDTO.Title} already exists.");
        }

        [HttpDelete("{idMovie}")]
        public async Task<IActionResult> DelteMovie(int idMovie)
        {
            var movie = await _dbService.DeleteMovie(idMovie);
            if (movie == null)
                return BadRequest($"There is no movie with that id {idMovie} in dataBase");
            return Ok($"The movie: {movie.Title} has been deleted");
        }

        [HttpGet("{idMovie}")]
        public async Task<IActionResult> GetMovie(int idMovie)
        {
            return Ok(await _dbService.GetMovie(idMovie));
        }
    }
}
