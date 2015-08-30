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
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PremierLeagueContext>());
            using(var context = new PremierLeagueContext())
            {
                var players = context.Players.ToList();
                var employees = context.Employees.ToList();
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
