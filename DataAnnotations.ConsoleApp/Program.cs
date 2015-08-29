
using DataAnnotations.Database;
using DataAnnotations.Database.Models;
using System.Linq;

namespace DataAnnotations.ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            using(var db = new PremierLeagueContext())
            {
                var player = db.Players.FirstOrDefault();
                player.Age = 414;
                db.Entry(player).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var newTeam = new Team()
                {
                    Name = "Bornemuth",
                    Division = "Premier League",

                };
                db.Teams.Add(newTeam);
                db.SaveChanges();
                System.Console.WriteLine(newTeam.DateCreated);
                //var refer = new Referee
                //{
                //    Id = 66,
                //    FullName = string.Empty
                //};
                //db.Referees.Add(refer);
                //db.SaveChanges();
                //var users = db.Users.Find(33, "9109184201");
                //var players = db.Players.ToList();
                //System.Console.WriteLine(users.UserForeignKeys.First().SomeData);
            };
        }
    }
}
