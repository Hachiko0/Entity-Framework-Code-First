using System.Linq;
using DatabaseInitializers.Database;

namespace DatabaseInitializers.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.Data.Entity.Database.SetInitializer(new MyInitializer());
            using (var db = new PremierLeagueContext())
            {            
                var players = db.Players.ToList();
                if(players.Count == 0)
                {
                    System.Console.WriteLine("There are no players in the database");
                }
                players.ForEach(p => System.Console.WriteLine(p));
            }
        }
    }
}
