using Microsoft.AspNetCore.Mvc;
using VideoKlub.Models;
using VideoKlub.Repository;

namespace VideoKlub.Controllers
{
    public class DirectorController : Controller
    {
        private readonly IGenericRepository<Director> _directorRepository;

        public DirectorController(IGenericRepository<Director> _director)
        {
            _directorRepository = _director;
        }

        [HttpGet]
        public IActionResult CreateDirector()
        {
            return View("CreateDirector");
        }

        [HttpPost]
        public IActionResult AddDirector(Director director)
        {
            if (ModelState.IsValid)
            {
                _directorRepository.Add(director);
            }
            return RedirectToAction("Create", "Movie");
        }

        [HttpGet]
        public IActionResult EditDirector(int id)
        {
            return View(_directorRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult SaveEditDirector(Director director)
        {
            if (ModelState.IsValid)
            {
                _directorRepository.Update(director);
            }
            return RedirectToAction("Create", "Movie");
        }

        [HttpGet]
        public IActionResult DeleteDirector(int id)
        {
            _directorRepository.Delete(id);

            return RedirectToAction("Movie", "Movie");
        }
    }
}