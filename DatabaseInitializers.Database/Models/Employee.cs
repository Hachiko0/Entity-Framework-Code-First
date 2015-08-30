using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseInitializers.Database
{
    public class Employee
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public override string ToString()
        {
            return this.FullName;
        }
    }
}
