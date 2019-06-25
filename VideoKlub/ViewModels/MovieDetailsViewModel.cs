using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VideoKlub.Models;

namespace VideoKlub.ViewModels
{
    public class MovieDetailsViewModel
    {
        public IEnumerable<Director> Directors { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        [Required]
        public Movie MovieMovie { get; set; }
        public Genre MovieGenre { get; set; }
        public Director MovieDirector { get; set; }
        public Actor MovieActor { get; set; }
    }
}
