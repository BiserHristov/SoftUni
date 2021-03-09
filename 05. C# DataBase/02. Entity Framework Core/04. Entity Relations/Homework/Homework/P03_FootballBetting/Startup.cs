using P03_FootballBetting.Data;
using System;

namespace P03_FootballBetting
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var context = new FootballBettingContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
