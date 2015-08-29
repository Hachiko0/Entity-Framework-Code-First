using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigureMappings.Database
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        public virtual ICollection<Match> HomeMatches { get; set; }

        public virtual ICollection<Match> AwayMatches { get; set; }

        public virtual ICollection<League> Leagues { get; set; }
    }
}
