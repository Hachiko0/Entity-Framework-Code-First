using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigureMappings.Database
{
    public class Referee : User
    {
        public int YellowCardsShowed { get; set; }

        public int RedCardsShowed { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}
