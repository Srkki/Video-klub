using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoKlub.Models;
using VideoKlub.Repository;

namespace VideoKlub.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenericRepository<Genre> _genreRepository;

        public GenreController(IGenericRepository<Genre> _genreRepository)
        {
            this._genreRepository = _genreRepository;
        }

        [HttpGet]
        public IActionResult CreateGenre()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGenre(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _genreRepository.Add(genre);
            }
            return RedirectToAction("Create", "Movie");
        }

        [HttpGet]
        public IActionResult EditGenre(int id)
        {
            return View(_genreRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult SaveEditGenre(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _genreRepository.Update(genre);
            }
            return RedirectToAction("Create", "Movie");
        }

        [HttpGet]
        public IActionResult DeleteGenre(int id)
        {
            _genreRepository.Delete(id);

            return RedirectToAction("Create", "Movie");
        }
    }
}