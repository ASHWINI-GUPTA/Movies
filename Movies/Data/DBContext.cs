using System;
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


            // Seed Data
            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().HasData(
                new Actor
                {
                    ActorId = 1,
                    Name = "Johnny Depp",
                    Bio =
                        "He was born John Christopher Depp II in Owensboro, Kentucky, on June 9, 1963, to Betty Sue (Wells), who worked as a waitress, and John Christopher Depp, a civil engineer.",
                    DOB = new DateTime(1983, 06, 9),
                    Sex = "Male"
                },
                new Actor
                {
                    ActorId = 2,
                    Name = "Leonardo DiCaprio",
                    Bio =
                        "DiCaprio has gone from relatively humble beginnings, as a supporting cast member of the sitcom Growing Pains (1985) and low budget horror movies, such as Critters 3 (1991), to a major teenage heartthrob in the 1990s",
                    DOB = new DateTime(1974, 11, 11),
                    Sex = "Male"
                },
                new Actor
                {
                    ActorId = 3,
                    Name = "Robert Downey Jr.",
                    Bio =
                        "Robert Downey Jr. has evolved into one of the most respected actors in Hollywood. With an amazing list of credits to his name, he has managed to stay new and fresh even after over four decades in the business.",
                    DOB = new DateTime(1965, 04, 04),
                    Sex = "Male"
                },
                new Actor
                {
                    ActorId = 4,
                    Name = "Scarlett Johansson",
                    Bio =
                        "Scarlett Johansson was born in New York City. Her mother, Melanie Sloan, is from a Jewish family from the Bronx, and her father, Karsten Johansson, is a Danish-born architect, from Copenhagen.",
                    DOB = new DateTime(1984, 11, 22),
                    Sex = "Female"
                },
                new Actor
                {
                    ActorId = 5,
                    Name = "Kate Winslet",
                    Bio = "--",
                    DOB = new DateTime(1975, 10, 05),
                    Sex = "Female"
                });

            modelBuilder.Entity<Producer>().HasData(
                new Producer
                {
                    Id = 1, Name = "James Cameron", Sex = "Male"
                },
                new Producer
                {
                    Id = 2, Name = "Jon Favreau", Sex = "Male"
                },
                new Producer
                {
                    Id = 3, Name = "Joss Whedon", Sex = "Male"
                });


            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    MovieName = "Titanic",
                    Plot =
                        "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.",
                    Released = new DateTime(1997, 01, 01),
                    ProducerId = 1
                },
                new Movie
                {
                    MovieId = 2,
                    MovieName = "Iron Man",
                    ProducerId = 2,
                    Plot =
                        "After being held captive in an Afghan cave, billionaire engineer Tony Stark creates a unique weaponized suit of armor to fight evil.",
                    Released = new DateTime(2008, 01, 01)
                },
                new Movie
                {
                    MovieId = 3,
                    ProducerId = 3,
                    Plot =
                        "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity.",
                    Released = new DateTime(2012, 01, 01),
                    MovieName = "The Avengers"
                });

            modelBuilder.Entity<ActorMovie>().HasData
            (
                new ActorMovie {ActorId = 2, MovieId = 1},
                new ActorMovie {ActorId = 5, MovieId = 1},
                new ActorMovie {ActorId = 3, MovieId = 2},
                new ActorMovie {ActorId = 3, MovieId = 3},
                new ActorMovie {ActorId = 4, MovieId = 3}
            );
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Actor> Actors { get; set; }
    }
}
