using CreateMovieAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CreateMovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        public List<Movie> Movies = new List<Movie>()
        {
            new Movie(){Title = "The Matrix", Genre = Genre.Action,ReleaseYear = 1999},
            new Movie(){Title = "Saving Private Ryan", Genre = Genre.Action, ReleaseYear = 1998 },
            new Movie(){Title = "Zoolander", Genre = Genre.Comedy, ReleaseYear = 2001},
            new Movie(){Title = "Texas Chainsaw Massacre", Genre= Genre.Horror, ReleaseYear = 1974},
            new Movie(){Title = "The Notebook", Genre = Genre.Romance, ReleaseYear = 2004},
            new Movie(){Title = "Soul", Genre = Genre.Animated, ReleaseYear = 2020},
            new Movie(){Title = "The King's Speech", Genre = Genre.Drama, ReleaseYear = 2010}
        };

        [HttpGet("FullMovieList")]
        public List<Movie> GetMovies()
        {
            return Movies;
        }

        [HttpGet("SearchByGenre/{genre}")]
        public List<Movie> SearchByGenre(Genre genre)
        {
            List<Movie> results = Movies.Where(x=>x.Genre == genre).ToList();
            return results;
        }

        [HttpGet("RandomMoviePick")]
        public Movie RandomMoviePick()
        {
            var random = new Random();
            int index = random.Next(Movies.Count);
            return Movies[index];
        }

        [HttpGet("RandomMoviePick/{genre}")]
        public Movie RandomByGenre(Genre genre)
        {
            List<Movie> results = Movies.Where(x => x.Genre == genre).ToList();
            var random = new Random();
            int index = random.Next(results.Count);
            return Movies[index];
        }

    }   
}
