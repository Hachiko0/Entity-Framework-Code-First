using FluentApi.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new PremierLeagueContext())
            {
                var emiratesMatch = context.Matches.Find(1);
                emiratesMatch.Date = DateTime.UtcNow;
                Console.WriteLine(emiratesMatch.Stadium);
                context.Entry(emiratesMatch).State = EntityState.Modified;

                //var user = new User
                //{
                //    Address = new Address
                //    {
                //        Id = 33
                //    }
                //};
                //context.Users.Add(user);
                context.SaveChanges();


                //var players = context.Players.ToList();
                //var employees = context.Employees.ToList();


                //var employee = new Employee()
                //{
                //    FullName = "Dimitar Berbatov",
                //    EmployeesThatLikeMe = new List<Employee>
                //    {
                //        new Employee()
                //        {
                //            FullName = "CSKA Fan"
                //        }
                //    }
                //};
                //context.Employees.Add(employee);
                //context.SaveChanges();
                //context.Database.Initialize(false);
            }
        }
    }
}   
