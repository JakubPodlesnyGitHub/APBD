using Microsoft.EntityFrameworkCore;
using MovieApp.Server.Data;
using MovieApp.Shared.DTOs;
using MovieApp.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Server.Services
{
    public interface IMoviesRepository
    {

    }

    public interface IMoviesDbService
    {
        Task<List<Movie>> GetMovies();

        Task<bool> AddMovie(MovieDTO newMovie);

        Task<Movie> GetMovie(int movieId);

        Task<Movie> DeleteMovie(int movieId);

        Task<bool> UpadteMovie(MovieDTO movie,int idMovie);
    }

    public class MoviesDbService : IMoviesDbService
    {
        private ApplicationDbContext _context;

        public MoviesDbService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddMovie(MovieDTO newMovie)
        {
            if (!await _context.Movies.AnyAsync(m => m.Title == newMovie.Title))
                return false;

            var movie = new Movie
            {
                Id = newMovie.Id,
                Title = newMovie.Title,
                Summary = newMovie.Title,
                InTheaters = newMovie.InTheaters,
                Trailer = newMovie.Trailer,
                ReleaseDate = newMovie.ReleaseDate,
                Poster = newMovie.Poster
            };
            _context.Movies.Attach(movie);
            _context.Entry(movie).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Movie> DeleteMovie(int movieId)
        {
            var movie = await _context.Movies.Where(m => m.Id == movieId).SingleOrDefaultAsync();
            if (movie == null)
                return null;

            _context.Movies.Attach(movie);
            _context.Entry(movie).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> GetMovie(int movieId)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);
            if (movie == null)
                return null;
            return movie;
        }

        public async Task<List<Movie>> GetMovies()
        {
            return await _context.Movies.OrderBy(m => m.Title).ToListAsync();
        }

        public async Task<bool> UpadteMovie(MovieDTO movie,int idMovie)
        {
            if (!await _context.Movies.AnyAsync(m => m.Id == idMovie))
                return false;

            var movieToUpdate = await _context.Movies.FirstOrDefaultAsync(m => m.Id == idMovie);
            
            movieToUpdate.Title = movie.Title;
            movieToUpdate.Summary = movie.Summary;
            movieToUpdate.InTheaters = movie.InTheaters;
            movieToUpdate.Trailer = movie.Trailer;
            movieToUpdate.ReleaseDate = movie.ReleaseDate;
            movieToUpdate.Poster = movie.Poster;
            
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
