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
                context.Database.Initialize(false);
            }
        }
    }
}
