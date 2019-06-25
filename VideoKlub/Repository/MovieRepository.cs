using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoKlub.Models;

namespace VideoKlub.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieModelContext _context;
        public MovieRepository(MovieModelContext context)
        {
            _context = context;
        }
        public Movie Add(Movie newMovie)
        {
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
            return newMovie;
        }

        public Movie Delete(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.MovieId == id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.Entry(movie).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            return movie;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.Movies;
        }

        public Movie GetMovie(int Id)
        {
            return _context.Movies.Find(Id);
        }

        public Movie Update(Movie movieUpdate)
        {
            var movie = _context.Movies.AsNoTracking().FirstOrDefault(m => m.MovieId == movieUpdate.MovieId);
            if (movie != null)
            {
                _context.Update(movieUpdate);
                _context.SaveChanges();
            }
            return movieUpdate;
        }
    }
}
