using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoKlub.Models;

namespace VideoKlub.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly MovieModelContext _context;
        public GenreRepository(MovieModelContext context)
        {
            _context = context;
        }

        public Genre Add(Genre newGenre)
        {
            var genre = _context.Genres.FirstOrDefault(
                                m => m.GenreColor == newGenre.GenreColor || 
                                m.GenreName.ToLower().Equals(newGenre.GenreName.ToLower())
                         );
            if (genre == null)
            {
                _context.Genres.Add(newGenre);
                _context.SaveChanges();
            }
            return newGenre;
        }

        public Genre Delete(int id)
        {
            Genre genre = _context.Genres.Find(id);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
                _context.SaveChanges();
            }
            return genre;
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _context.Genres;
        }

        public Genre GetGenre(int Id)
        {
            return _context.Genres.Find(Id);
        }

        public Genre Update(Genre genreChanges)
        {
            var genre = _context.Genres.Attach(genreChanges);
            genre.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return genreChanges;
        }
    }
}
