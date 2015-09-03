using System.Linq;
using DatabaseInitializers.Database;
using System.Data.Entity;

namespace DatabaseInitializers.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new PremierLeagueContext())
            {
                var players = db.Players.ToList();
                players.ForEach(p => System.Console.WriteLine(p.FirstName));
            }
        }
    }
}
