using System.Collections.Generic;
using VideoKlub.Models;

namespace VideoKlub.Repository
{
    public class ActorRepository : IActorRepository
    {
        private readonly MovieModelContext _context;
        public ActorRepository(MovieModelContext context)
        {
            _context = context;
        }
        public Actor Add(Actor newActor)
        {
            _context.Actors.Add(newActor);
            _context.SaveChanges();
            return newActor;
        }

        public Actor Delete(int id)
        {
            Actor actor = _context.Actors.Find(id);
            if (actor != null)
            {
                _context.Actors.Remove(actor);
                _context.SaveChanges();
            }
            return actor;
        }

        public Actor GetActor(int Id)
        {
            return _context.Actors.Find(Id);
        }

        public IEnumerable<Actor> GetAllActors()
        {
            return _context.Actors;
        }

        public Actor Update(Actor actorChanges)
        {
            var actor = _context.Actors.Attach(actorChanges);
            actor.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return actorChanges;
        }
    }
}
