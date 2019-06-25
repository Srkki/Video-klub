using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoKlub.Models;

namespace VideoKlub.Repository
{
    public interface IActorRepository
    {
        Actor GetActor(int Id);
        IEnumerable<Actor> GetAllActors();
        Actor Add(Actor newActor);
        Actor Update(Actor actorChanges);
        Actor Delete(int id);
    }
}
