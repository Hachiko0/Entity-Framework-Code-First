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
                context.Database.CreateIfNotExists();
                context.SaveChanges();
            }
        }
    }
}   
