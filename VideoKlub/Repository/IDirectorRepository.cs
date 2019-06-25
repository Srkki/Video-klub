using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoKlub.Models;

namespace VideoKlub.Repository
{
    public interface IDirectorRepository
    {
        Director GetDirector(int Id);
        IEnumerable<Director> GetAllDirectors();
        Director Add(Director newDirector);
        Director Update(Director directorChanges);
        Director Delete(int id);
    }
}
