using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAnnotations.Database
{
    public class User
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public string EGN { get; set; }

        public string FirstName { get; set; }

        public string FamilyName { get; set; }

        public Address Address { get; set; }

        public virtual ICollection<UserForeignKey> UserForeignKeys { get; set; }
    }
}
