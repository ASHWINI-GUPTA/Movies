using Movies.Models;
using Microsoft.EntityFrameworkCore;

namespace Movies.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMovie>()
                .HasKey(am => new { am.MovieId, am.ActorId });

            modelBuilder.Entity<ActorMovie>()
                .HasOne(pt => pt.Movie)
                .WithMany(p => p.ActorMovies)
                .HasForeignKey(pt => pt.MovieId);

            modelBuilder.Entity<ActorMovie>()
                .HasOne(pt => pt.Actor)
                .WithMany(t => t.ActorMovies)
                .HasForeignKey(pt => pt.ActorId);
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Actor> Actors { get; set; }
    }
}
