namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Console.WriteLine(ExportAlbumsInfo(context, 9));
            Console.WriteLine(ExportSongsAboveDuration(context, 4));


        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {

            var albums = context.Albums
                .Where(x => x.ProducerId == producerId)
                .Select(x => new
                {
                    TotalPrice = x.Price,
                    AlbumName = x.Name,
                    AlbumRDate = x.ReleaseDate,
                    ProducerName = x.Producer.Name,
                    Songs = x.Songs
                        .OrderByDescending(s => s.Name)
                        .ThenBy(s => s.Writer.Name)
                        .Select(s => new
                        {
                            SongName = s.Name,
                            SongPrice = s.Price,
                            SongWriter = s.Writer.Name
                        })
                        .ToList()
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var album in albums.OrderByDescending(a => a.TotalPrice))
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.AlbumRDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");

                var i = 1;
                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{i++}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.SongPrice:F2}");
                    sb.AppendLine($"---Writer: {song.SongWriter}");

                }

                sb.AppendLine($"-AlbumPrice: {album.TotalPrice:F2}");




            }
            return sb.ToString().Trim();
        }


        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var allSongs = context.Songs
                //.ToList()
                .Where(s => s.Duration > TimeSpan.FromSeconds(duration))
                .Select(s => new
                {
                    SongName = s.Name,
                    WriterName = s.Writer.Name,
                    PerformerFullName = s.SongPerformers
                                            .Select(p => p.Performer.FirstName + " " + p.Performer.LastName)
                                            .FirstOrDefault(),
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .ThenBy(s => s.PerformerFullName)
                .ToList();


            var sb = new StringBuilder();
            var i = 1;
            foreach (var song in allSongs)
            {
                sb.AppendLine($"-Song #{i++}")
                  .AppendLine($"---SongName: {song.SongName}")
                  .AppendLine($"---Writer: {song.WriterName}")
                  .AppendLine($"---Performer: {song.PerformerFullName}")
                  .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                  .AppendLine($"---Duration: {song.Duration:c}");

            }



            return sb.ToString().Trim();
        }

        //    Export the songs which are above the given duration.
        //For each Song, export its Name, Performer Full Name, Writer Name, Album Producer and Duration(in format("c")). Sort the Songs by their Name(ascending), by Writer(ascending) and by Performer(ascending).
    }
}
