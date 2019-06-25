using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoKlub.Models;

namespace VideoKlub.Repository
{
    public interface IMovieRepository
    {
        Movie GetMovie(int Id);
        IEnumerable<Movie> GetAllMovies();
        Movie Add(Movie newMovie);
        Movie Update(Movie movieChanges);
        Movie Delete(int id);
    }
}
