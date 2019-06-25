using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoKlub.Models;

namespace VideoKlub.Repository
{
    public interface IGenreRepository
    {
        Genre GetGenre(int Id);
        IEnumerable<Genre> GetAllGenres();
        Genre Add(Genre newGenre);
        Genre Update(Genre genreChanges);
        Genre Delete(int id);
    }
}
