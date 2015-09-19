using ConfigureMappings.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigureMappings.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new PremierLeagueContext())
            {
                var playerAddress = new PlayerAddress { City = "Varna" };
                var player = new Player
                {
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    Age = 34,
                    Address = playerAddress
                };
                context.Players.Add(player);

                //var referee = new Referee
                //{
                //    EGN = "3274723428",
                //    FirstName = "Howard",
                //    FamilyName = "Webb",
                //    RedCardsShowed = 65,
                //    YellowCardsShowed = 150,
                //};

                //context.Referees.Add(referee);
                context.SaveChanges();
            }
        }
    }
}
