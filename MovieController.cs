using Microsoft.AspNetCore.Mvc;

namespace OMDBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpGet("GetMovieByTitle")]
        public IActionResult GetMovieByTitle()
        {
            var omdbMovie = GetOMDBMovieAsync("https://www.omdbapi.com/?i=tt3896198&apikey=4f5cda79").Result;
            var movie = new Movie();
            movie.MovieTitle = omdbMovie.Title;
         
            return Ok(omdbMovie); //return movie object
           
        }

        [HttpGet("{Title}")]
        public IActionResult GetMovieWithDetails(string Title)
        {
            var omdbMovieDetails = GetOMDBMovieAsync("https://www.omdbapi.com/?i=tt3896198&apikey=4f5cda79&t=" + Title).Result;
            var movie = new Movie();
                movie.MovieTitle = omdbMovieDetails.Title;
                movie.MyYear = omdbMovieDetails.Year;
                movie.MyDescription = omdbMovieDetails.Rated;

            return Ok(movie);
        }
        static async Task<OMDBMovie> GetOMDBMovieAsync(string path)
        {
            HttpClient client = new HttpClient();
            OMDBMovie omdbMovie = new OMDBMovie();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                omdbMovie = await response.Content.ReadFromJsonAsync<OMDBMovie>();
            }
            return omdbMovie;
        }
    }
}