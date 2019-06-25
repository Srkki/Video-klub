using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoKlub.Models;

namespace VideoKlub.Repository
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly MovieModelContext _context;
        private DbSet<Entity> table = null;

        public GenericRepository(MovieModelContext context)
        {
            this._context = context;
            table = _context.Set<Entity>();
        }

        public void Add(Entity obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(object id)
        {
            Entity entity = table.Find(id);
            if (entity != null)
            {
                table.Remove(entity);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Entity> GetAll()
        {
            return table.ToList();
        }

        public Entity GetById(object id)
        {
            return table.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Entity obj)
        {
            var director = table.Attach(obj);
            director.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
