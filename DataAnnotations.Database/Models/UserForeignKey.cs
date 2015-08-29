using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotations.Database
{
    public class UserForeignKey
    {
        [Column(Order = 0)]
        public int Id { get; set; }

        public string SomeData { get; set; }

        [ForeignKey("User")]
        [Column(Order = 2)]
        public int UserId { get; set; }

        [ForeignKey("User")]
        [Column(Order = 3)]
        [Required]
        public string EGNId { get; set; }

        public User User { get; set; }
    }
}
