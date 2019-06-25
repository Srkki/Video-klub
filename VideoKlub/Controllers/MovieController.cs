using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VideoKlub.Models;
using VideoKlub.Repository;
using VideoKlub.ViewModels;

namespace VideoKlub.Controllers
{
    public class MovieController : Controller
    {
        private readonly IGenericRepository<Movie> _movieRepository;
        private readonly IGenericRepository<Director> _directorRepository;
        private readonly IGenericRepository<Genre> _genreRepository;
        private readonly IGenericRepository<Actor> _actorRepository;
        public MovieController(IGenericRepository<Movie> movieRepository,
                            IGenericRepository<Director> directorRepository,
                            IGenericRepository<Genre> genreRepository,
                            IGenericRepository<Actor> actorRepository)
        {
            _movieRepository = movieRepository;
            _directorRepository = directorRepository;
            _genreRepository = genreRepository;
            _actorRepository = actorRepository;
        }

        [HttpGet]
        public IActionResult Movie()
        {
            return View(GetAllMovieDetailsJoined());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(GetAll());
        }

        [HttpPost]
        public IActionResult Create(MovieDetailsViewModel movie)
        {
            if (ModelState.IsValid)
            {
                _movieRepository.Add(movie.MovieMovie);
            }
            return RedirectToAction("Movie", "Movie");
        }

        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            MovieDetailsViewModel moviDetailsVM = GetAll();
            moviDetailsVM.MovieMovie = GetAllMovieDetailsJoined().Where(m => m.MovieMovie.MovieId == id).SingleOrDefault().MovieMovie;

            return View(moviDetailsVM);
        }

        public IActionResult SaveUpdate(MovieDetailsViewModel movieUpdate)
        {
            if (ModelState.IsValid)
            {
                _movieRepository.Update(movieUpdate.MovieMovie);
            }
            return RedirectToAction("Movie", "Movie");
        }

        [HttpGet]
        public IActionResult DeleteMovie(int id)
        {
            _movieRepository.Delete(id);

            return RedirectToAction("Movie", "Movie");
        }

        private IEnumerable<MovieDetailsViewModel> GetAllMovieDetailsJoined()
        {
            List<Movie> movies = _movieRepository.GetAll().ToList();
            List<Director> directors = _directorRepository.GetAll().ToList();
            List<Genre> genres = _genreRepository.GetAll().ToList();
            List<Actor> actors = _actorRepository.GetAll().ToList();

            var joinedTbl = from m in movies
                            join d in directors on m.DirectorId equals d.DirectorId
                            join g in genres on m.GenreId equals g.GenreId
                            join a in actors on m.ActorId equals a.ActorId
                            select new MovieDetailsViewModel
                            {
                                MovieMovie = m,
                                MovieDirector = d,
                                MovieGenre = g,
                                MovieActor = a,

                                Movies = movies,
                                Directors = directors,
                                Genres = genres,
                                Actors = actors
                            };
            return joinedTbl;
        }

        private MovieDetailsViewModel GetAll()
        {
            MovieDetailsViewModel movieDetailsViewModel = new MovieDetailsViewModel()
            {
                Directors = _directorRepository.GetAll(),
                Genres = _genreRepository.GetAll(),
                Actors = _actorRepository.GetAll(),
                Movies = _movieRepository.GetAll()
            };
            return movieDetailsViewModel;
        }
    }
}
