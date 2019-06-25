using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VideoKlub.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Required]
        public string MovieName { get; set; }
        [ForeignKey("Director")]
        public int DirectorId { get; set; }
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        [ForeignKey("Actor")]
        public int ActorId { get; set; }
    }
}
