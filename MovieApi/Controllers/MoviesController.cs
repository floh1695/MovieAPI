using MovieApi.Contexts;
using MovieApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        // POST api/movies
        public Movie Post
            (string title, int? yearReleased = null, string genre = null,
            string tagline = null, double? rating = null)
        {
            using (var db = new MoviesDB())
            {
                var movie = new Movie
                {
                    Title = title,
                    YearReleased = yearReleased,
                    Genre = genre,
                    Tagline = tagline,
                    Rating = rating,
                };
                db.Movies.Add(movie);
                db.SaveChanges();
                return movie;
            }
        }
    }
}
