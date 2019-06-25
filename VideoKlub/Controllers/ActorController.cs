using Microsoft.AspNetCore.Mvc;
using VideoKlub.Models;
using VideoKlub.Repository;

namespace VideoKlub.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorRepository _actorRepository;

        public ActorController(IActorRepository _actorRepository)
        {
            this._actorRepository = _actorRepository;
        }

        [HttpGet]
        public IActionResult CreateActor()
        {
            return View("CreateActor");
        }

        [HttpPost]
        public IActionResult AddActor(Actor actor)
        {
            if (ModelState.IsValid)
            {
                _actorRepository.Add(actor);
            }
            return RedirectToAction("Create", "Movie");
        }

        [HttpGet]
        public IActionResult EditActor(int id)
        {
            return View(_actorRepository.GetActor(id));
        }

        [HttpPost]
        public IActionResult SaveEditActor(Actor actor)
        {
            if (ModelState.IsValid)
            {
                _actorRepository.Update(actor);
            }
            return RedirectToAction("Movie", "Movie");
        }

        [HttpGet]
        public IActionResult DeleteActor(int id)
        {
            _actorRepository.Delete(id);

            return RedirectToAction("Movie", "Movie");
        }
    }
}