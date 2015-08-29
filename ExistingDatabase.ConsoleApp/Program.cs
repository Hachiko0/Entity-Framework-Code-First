using ExistingDatabase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExistingDatabase.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new Northwind())
            {
                var newEmployee = new Employee()
                {
                    FirstName = "Misho",
                    LastName = "Mishev",
                    Title = "no Title",
                    BirthDate = new DateTime(2008,8,8),

                };

                db.Employees.Add(newEmployee);
                db.SaveChanges();
                Console.WriteLine(newEmployee.HireDate);
            }
        }
    }
}
