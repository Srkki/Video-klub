using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using VideoKlub.Models;
using VideoKlub.Repository;
using VideoKlub.ViewModels;

namespace VideoKlub.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericRepository<Movie> _movieRepository;
        private readonly IGenericRepository<Director> _directorRepository;
        private readonly IGenericRepository<Genre> _genreRepository;
        private readonly IGenericRepository<Actor> _actorRepository;
        public HomeController(IGenericRepository<Movie> movieRepository,
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
        public IActionResult Index()
        {
            return View(GetAllMovieDetailsJoined());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
    }
}
