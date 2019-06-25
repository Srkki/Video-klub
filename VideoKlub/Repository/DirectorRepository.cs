using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoKlub.Models;

namespace VideoKlub.Repository
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly MovieModelContext _context;
        public DirectorRepository(MovieModelContext context)
        {
            _context = context;
        }
        public Director Add(Director newDirector)
        {
            _context.Directors.Add(newDirector);
            _context.SaveChanges();
            return newDirector;
        }

        public Director Delete(int id)
        {
            Director director = _context.Directors.Find(id);
            if (director != null)
            {
                _context.Directors.Remove(director);
                _context.SaveChanges();
            }
            return director;
        }

        public IEnumerable<Director> GetAllDirectors()
        {
            return _context.Directors;
        }

        public Director GetDirector(int Id)
        {
            return _context.Directors.Find(Id);
        }

        public Director Update(Director directorChanges)
        {
            var director = _context.Directors.Attach(directorChanges);
            director.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return directorChanges;
        }
    }
}
