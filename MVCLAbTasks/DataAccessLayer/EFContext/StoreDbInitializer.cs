using System.Collections.Generic;
using System.Data.Entity;
using DataAccessLayer.Entities;

namespace DataAccessLayer.EFContext
{
    class StoreDbInitializer : DropCreateDatabaseAlways<StoreDbContext>
    {
        protected override void Seed(StoreDbContext context)
        {
            PlatformType pt = new PlatformType { Type = "mobile" };
            context.PlatformTypes.Add(pt);
            pt = new PlatformType { Type = "browser" };
            context.PlatformTypes.Add(pt);
            pt = new PlatformType { Type = "desktop" };
            context.PlatformTypes.Add(pt);
            pt = new PlatformType { Type = "console" };
            context.PlatformTypes.Add(pt);

            Genre strategy = new Genre { Name = "Strategy" };
            context.Genres.Add(strategy);

            Genre gr = new Genre { Name = "RTS", SubGenre = strategy };
            context.Genres.Add(gr);

            gr = new Genre { Name = "TBS", SubGenre = strategy };
            context.Genres.Add(gr);

            gr = new Genre { Name = "RPG" };
            context.Genres.Add(gr);

            gr = new Genre { Name = "Sports" };
            context.Genres.Add(gr);

            Genre race = new Genre { Name = "Races" };
            context.Genres.Add(gr);

            gr = new Genre { Name = "rally", SubGenre = race };
            context.Genres.Add(gr);

            gr = new Genre { Name = "arcade", SubGenre = race };
            context.Genres.Add(gr);

            gr = new Genre { Name = "formula", SubGenre = race };
            context.Genres.Add(gr);

            gr = new Genre { Name = "off-road", SubGenre = race };
            context.Genres.Add(gr);

            Genre action = new Genre { Name = "Action" };
            context.Genres.Add(gr);

            gr = new Genre { Name = "FPS", SubGenre = action };
            context.Genres.Add(gr);

            gr = new Genre { Name = "TPS", SubGenre = action };
            context.Genres.Add(gr);

            gr = new Genre { Name = "Adventure" };
            context.Genres.Add(gr);

            gr = new Genre { Name = "Puzzle&Skill" };
            context.Genres.Add(gr);

            context.Genres.Add(gr);

            Game gm = new Game()
            {
                Description = "First game",
                Name = "Game1",
                Key = "Key1",
                Genres = new List<Genre>() {action, gr}
            };
            context.Games.Add(gm);
            gm = new Game()
            {
                Description = "Second game",
                Name = "Game2",
                Key = "Key2",
                Genres = new List<Genre>() { action, gr }
            };
            context.Games.Add(gm);
            gm = new Game()
            {
                Description = "Third game",
                Name = "Game3",
                Key = "Key3",
                Genres = new List<Genre>() { action, gr }
            };
            context.Games.Add(gm);

            Comment cm = new Comment(){Author = "Me", Name = "name1", Body = "Ia ia ia", Game = gm };
            context.Comments.Add(cm);
            cm = new Comment() { Author = "Mee", Name = "namee1", Body = "Ia ia iaa", Game = gm };
            context.Comments.Add(cm);
            base.Seed(context);
        }
    }
}
