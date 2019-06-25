using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoKlub.Models;
using VideoKlub.Repository;
using VideoKlub.ViewModels;

namespace VideoKlub.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IDirectorRepository _directorRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IActorRepository _actorRepository;
        public MovieController(IMovieRepository movieRepository,
                            IDirectorRepository directorRepository,
                            IGenreRepository genreRepository,
                            IActorRepository actorRepository)
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
            MovieDetailsViewModel movieDetailsViewModel = new MovieDetailsViewModel()
            {
                Directors = _directorRepository.GetAllDirectors(),
                Genres = _genreRepository.GetAllGenres(),
                Actors = _actorRepository.GetAllActors(),
                Movies = _movieRepository.GetAllMovies()
            };
            return View(movieDetailsViewModel);
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
            MovieDetailsViewModel movieDetailsViewModel = new MovieDetailsViewModel()
            {
                Directors = _directorRepository.GetAllDirectors(),
                Genres = _genreRepository.GetAllGenres(),
                Actors = _actorRepository.GetAllActors(),
                Movies = _movieRepository.GetAllMovies(),

                MovieMovie = GetAllMovieDetailsJoined().Where(m => m.MovieMovie.MovieId == id).SingleOrDefault().MovieMovie
            };

            return View(movieDetailsViewModel);
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

            return RedirectToAction("Index", "Home");
        }

        private IEnumerable<MovieDetailsViewModel> GetAllMovieDetailsJoined()
        {
            List<Movie> movies = _movieRepository.GetAllMovies().ToList();
            List<Director> directors = _directorRepository.GetAllDirectors().ToList();
            List<Genre> genres = _genreRepository.GetAllGenres().ToList();
            List<Actor> actors = _actorRepository.GetAllActors().ToList();

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
    }
}
