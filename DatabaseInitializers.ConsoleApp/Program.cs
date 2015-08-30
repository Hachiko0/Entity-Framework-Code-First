using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DatabaseInitializers.Database;

namespace DatabaseInitializers.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseAlways<PremierLeagueContext>());

            using(var db = new PremierLeagueContext())
            {
                var players = db.Players.ToList();
            }
        }
    }
}
