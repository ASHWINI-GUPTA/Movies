using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "ActorId", "Bio", "DOB", "Name", "Sex" },
                values: new object[,]
                {
                    { 1, "He was born John Christopher Depp II in Owensboro, Kentucky, on June 9, 1963, to Betty Sue (Wells), who worked as a waitress, and John Christopher Depp, a civil engineer.", new DateTime(1983, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnny Depp", "Male" },
                    { 2, "DiCaprio has gone from relatively humble beginnings, as a supporting cast member of the sitcom Growing Pains (1985) and low budget horror movies, such as Critters 3 (1991), to a major teenage heartthrob in the 1990s", new DateTime(1974, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leonardo DiCaprio", "Male" },
                    { 3, "Robert Downey Jr. has evolved into one of the most respected actors in Hollywood. With an amazing list of credits to his name, he has managed to stay new and fresh even after over four decades in the business.", new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Downey Jr.", "Male" },
                    { 4, "Scarlett Johansson was born in New York City. Her mother, Melanie Sloan, is from a Jewish family from the Bronx, and her father, Karsten Johansson, is a Danish-born architect, from Copenhagen.", new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scarlett Johansson", "Female" },
                    { 5, "--", new DateTime(1975, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kate Winslet", "Female" }
                });

            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "Id", "Bio", "Name", "Sex" },
                values: new object[,]
                {
                    { 1, null, "James Cameron", "Male" },
                    { 2, null, "Jon Favreau", "Male" },
                    { 3, null, "Joss Whedon", "Male" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "MovieName", "Plot", "Poster", "ProducerId", "Released" },
                values: new object[] { 1, "Titanic", "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.", null, 1, new DateTime(1997, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "MovieName", "Plot", "Poster", "ProducerId", "Released" },
                values: new object[] { 2, "Iron Man", "After being held captive in an Afghan cave, billionaire engineer Tony Stark creates a unique weaponized suit of armor to fight evil.", null, 2, new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "MovieName", "Plot", "Poster", "ProducerId", "Released" },
                values: new object[] { 3, "The Avengers", "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity.", null, 3, new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "MovieId", "ActorId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 5 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActorMovie",
                keyColumns: new[] { "MovieId", "ActorId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ActorMovie",
                keyColumns: new[] { "MovieId", "ActorId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "ActorMovie",
                keyColumns: new[] { "MovieId", "ActorId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ActorMovie",
                keyColumns: new[] { "MovieId", "ActorId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ActorMovie",
                keyColumns: new[] { "MovieId", "ActorId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
