
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ConfigureMappings.Database
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int? TeamId { get; set; } 
        public virtual Team Team { get; set; }

        public int? SubstituteId { get; set; }
        public virtual Player Substitute { get; set; }

        public virtual ICollection<Player> Substitues { get; set; }

        public virtual PlayerAddress Address { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }
}
