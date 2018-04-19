using MovieApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieApi.Contexts
{
    public class MoviesDB : DbContext
    {
        public MoviesDB()
            : base("name=Movies")
        { }

        public DbSet<Movie> Movies { get; set; }
    }
}