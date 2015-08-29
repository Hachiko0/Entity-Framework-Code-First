using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi.Database
{
    public class Team
    {
        public int TeamPrimmaryKey { get; set; }

        public string Name { get; set; }
    }
}
