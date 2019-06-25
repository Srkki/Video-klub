using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoKlub.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        [Required]
        public string GenreName { get; set; }
        public string GenreColor { get;set; }
    }
}
