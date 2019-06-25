using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoKlub.Repository
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        IEnumerable<Entity> GetAll();
        Entity GetById(object id);
        void Add(Entity obj);
        void Update(Entity obj);
        void Delete(object id);
        void Save();
    }
}
