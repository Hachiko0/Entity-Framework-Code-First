using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigureMappings.Database
{
    public class Coach : User
    {
        public int Age { get; set; }

        public string Nationality { get; set; }

        public string WonTrophies { get; set; }
    }
}
