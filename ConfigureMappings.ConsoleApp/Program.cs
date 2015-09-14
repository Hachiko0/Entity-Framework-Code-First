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
                var referee = new Referee
                {
                    EGN = "327472342",
                    FirstName = "Howard",
                    FamilyName = "Webb",
                    RedCardsShowed = 65,
                    YellowCardsShowed = 150,
                };

                context.Referees.Add(referee);
                context.SaveChanges();
            }
        }
    }
}
