namespace HeritageTrailsAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using HeritageTrailsAPI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<HeritageTrailsAPI.Models.HeritageTrailsAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HeritageTrailsAPI.Models.HeritageTrailsAPIContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Trails.AddOrUpdate(x => x.TrailId,
              new Trail() { TrailId = 1, Name = "Trail of memories", Time = "1.5hrs", Length = "3.0km", PictureInt = 2130837633 },
              new Trail() { TrailId = 2, Name = "Cobblers and Convicts", Time = "0.6hrs", Length = "2.5km", PictureInt = 2130837634 },
              new Trail() { TrailId = 3, Name = "Rediscover the terrace", Time = "2.5hrs", Length = "3.5km", PictureInt = 2130837635 }
          );

            context.Stops.AddOrUpdate(x => x.StopId,
               new Stop() {
                   StopId = 1,
                   Name = "Claremont Station",
                   ShortDesc = "Old Claremont railway station",
                   FullDesc = "Old Claremont railway station is located the quick brown fox jumps etc etc",
                   Built = "1898",
                   Location = "Corner of Railway Parade and Stirling Highway",
                   CoordX = "-31.980709",
                   CoordY = "115.781455",
                   Image = 2130837636,
                   VideoURL = "",
                   TrailId = 1 },
               new Stop() {
                   StopId = 2,
                   Name = "Heritage Precint",
                   ShortDesc = "The area bounded by Mary, Gugeri, Melville and Loch Streets",
                   FullDesc = "Old Claremont railway station is located the quick brown fox jumps etc etc",
                   Built = "1915",
                   Location = "The area bounded by Mary, Gugeri, Melville and Loch Streets",
                   CoordX = "-31.979600",
                   CoordY = "115.784943",
                   Image = 2130837637,
                   VideoURL = "",
                   TrailId = 1 },
               new Stop() {
                   StopId = 3,
                   Name = "Wyandra House",
                   ShortDesc = "A magnificent and unusually large Federation Bungalow",
                   FullDesc = "Wyandra was built in 1906 for Sydney Roberts, a civil servant and Registrar of Mines. This magnificent and unusually large Federation Bungalow started life as a typical four room residence with a verandah.",
                   Location = "4 Melville Street",
                   Built = "1906",
                   CoordX = "-31.976508",
                   CoordY = "115.787815",
                   Image = 2130837638,
                   VideoURL = "",
                   TrailId = 1 },
               new Stop()
               {
                   StopId = 4,
                   Name = "St Thomas Church",
                   ShortDesc = "Church for the parish of St Thomas, named after the Apostle, ‘Doubting Thomas’",
                   FullDesc = "emerged from the Cottesloe Parish in 1904 with Mass celebrated in Bowers Hall, opposite Claremont Railway Station, by Fr Thomas Masterson.  A Catholic School was established in Reserve Street and this school doubled as a place for Mass and other parish activities until it burnt down in 1913.",
                   Location = "4 Melville Street",
                   Built = "1904",
                   CoordX = "-31.978014",
                   CoordY = "115.788408",
                   Image = 2130837639,
                   VideoURL = "",
                   TrailId = 1
               },
               new Stop()
               {
                   StopId = 5,
                   Name = "UWA Endowment Land",
                   ShortDesc = "Short description goes here",
                   FullDesc = "Full description goes here - s simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                   Location = "Location goes here",
                   Built = "Date built",
                   CoordX = "-31.974690",
                   CoordY = "115.789935",
                   Image = 2130837640,
                   VideoURL = "",
                   TrailId = 1
               }
           );
        }
    }
}
