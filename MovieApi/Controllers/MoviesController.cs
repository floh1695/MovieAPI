using MovieApi.Contexts;
using MovieApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MovieApi.Controllers
{
    public class MoviesController : ApiController
    {
        // GET api/movies
        public IEnumerable<Movie> Get()
        {
            using (var db = new MoviesDB())
            {
                return db.Movies.ToList();
            }
        }

        // GET api/movies/5
        public Movie Get(int ID)
        {
            using (var db = new MoviesDB())
            {
                return db.Movies.FirstOrDefault(m => m.ID == ID);
            }
        }

        //public IEnumerable<Movie> Get(string title)
        //{
        //    return Get(title, "");
        //}

        // GET api/movies?title=title&genre=genre
        public IEnumerable<Movie> Get(string title, string genre)
        {
            using (var db = new MoviesDB())
            {
                bool containsWrap(string haystack, string needle)
                {
                    if (haystack == null) { return false; }
                    else if (haystack.Count() == 0) { return true; }
                    return haystack.Contains(needle);
                }
                return db.Movies
                    .ToList()
                    .Where(m => containsWrap(m.Title, title))
                    .Where(m => containsWrap(m.Genre, genre));            }
        }

        // POST api/movies
        public Movie Post
            (string title, string genre = null)
        {
            var movie = new Movie
            {
                Title = title,
                //YearReleased = yearReleased,
                Genre = genre,
                //Tagline = tagline,
                //Rating = rating,
            };
            using (var db = new MoviesDB())
            {
                db.Movies.Add(movie);
                db.SaveChanges();
            }
            return movie;
        }

        // POST api/movies
        public async Task<Movie> Post(HttpRequestMessage request)
        {
            var jsonString = await request.Content.ReadAsStringAsync();
            var movie = JsonConvert.DeserializeObject<Movie>(jsonString);
            using (var db = new MoviesDB())
            {
                db.Movies.Add(movie);
                db.SaveChanges();
            }
            return movie;
        }
    }
}
