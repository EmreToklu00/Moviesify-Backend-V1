using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.DTO;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace DataAccess.Concrete
{
    public class SeedDatabase
    {
        public static void Seed()
        {

            using (var context = new MoviesifyContext())
            {

                if (context.Database.GetPendingMigrations().Count() == 0)
                {
                    if (context.Publishers.Count() == 0)
                    {
                        context.Publishers.AddRange(publisher1, publisher2, publisher3);

                    }
                    else if (context.Categories.Count() == 0)
                    {
                        context.Categories.AddRange(category1, category2);
                    }
                }
                context.SaveChanges();
            }
        }

        //Models


        /* private static Movie movie1 = new()
         {
             MovieId = new Guid(),
             CategoryId = category1.CategoryId,
             Category = category1,
             PublisherId = publisher1.PublisherId,
             Publisher = publisher1,
             Name = "Harry Potter Test",
             Description = "Harry Potter Description Test",
             ImageUrl = "https://cdn.hornbach.nl/data/shop/D04/001/780/492/381/818/DV_8_10578386_01_4c_DE_20220704181753.jpg",
             IMDb = 8,
             PublishYear = Convert.ToDateTime("Jan 24, 2002"),
         };

         private static Movie movie2 = new()
         {
             MovieId = new Guid(),
             Category = category2,
             CategoryId = category2.CategoryId,
             Publisher = publisher2,
             PublisherId = publisher2.PublisherId,
             Name = "Game of Thrones Test",
             Description = "Game of Thrones Description Test",
             ImageUrl = "https://static.hbo.com/art-1920x1080.jpg",
             IMDb = 9,
             PublishYear = Convert.ToDateTime("Sep 18, 2005"),
         };

         private static Movie movie3 = new()
         {
             MovieId = new Guid(),
             Category = category2,
             CategoryId = category2.CategoryId,
             Publisher = publisher3,
             PublisherId = publisher3.PublisherId,
             Name = "Avengers: Endgame Test",
             Description = "Avengers: Endgame Description Test",
             ImageUrl = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcQA_-tL18_rj9zEcjN6n41NEaJm-kRNF9UeOtvksZ4z_OW6jRA9",
             IMDb = 10,
             PublishYear = Convert.ToDateTime("Jan 10, 2020"),
         };*/

        private static Category category1 = new() { Name = "Adventure", CategoryId = new Guid(), Description = "Adventure Test Descriptsion", Movies = { } };
        private static Category category2 = new() { Name = "Action", CategoryId = new Guid(), Description = "Action Test Descriptsion", Movies = { } };

        private static Publisher publisher1 = new()
        {
            PublisherId = new Guid(),
            Name = "Warner Bros",
            Email = "WarnerBros@gmail.com",
            Address = "Warner Bros Street",
            EstablishedDate = DateTime.Now,
            Movies = { },
        };
        private static Publisher publisher2 = new()
        {
            PublisherId = new Guid(),
            Name = "HBO",
            Email = "HBO@gmail.com",
            Address = "HBO Street",
            EstablishedDate = DateTime.Now,
            Movies = { },
        }; private static Publisher publisher3 = new()
        {
            PublisherId = new Guid(),
            Name = "Marvel",
            Email = "Marvel@gmail.com",
            Address = "Marvel Street",
            EstablishedDate = DateTime.Now,
            Movies = { },
        };
    }














}
