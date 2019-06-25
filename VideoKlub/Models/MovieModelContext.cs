using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VideoKlub.Models
{
    public class MovieModelContext :IdentityDbContext
    {
        public MovieModelContext(DbContextOptions<MovieModelContext> options)   : base(options)
        {
        }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
