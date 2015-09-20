using ConfigureMappings.Database;
using System;
using System.Data.Entity;
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
                context.Database.CreateIfNotExists();
                var firstPlayer = context.Players.FirstOrDefault(); //get only the columns(properties) from the player class
                //var firstPlayerWithPhoto = context.Players.Include(p => p.Photo).FirstOrDefault(); //get the player and playerPhoto columns
                  
                //var playerAddress = new PlayerAddress { City = "Varna" };
                //var player = new Player
                //{
                //    FirstName = "Ivan",
                //    LastName = "Ivanov",
                //    Age = 34,
                //    Address = playerAddress,
                //    Photo = new PlayerPhoto() {  Photo = new byte[4] {1,2,3,4}, FileName = "aaa.txt" }
                //};
                //context.Players.Add(player);

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
