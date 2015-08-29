using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigureMappings.Database
{
    public class UserForeignKey
    {
        public int Id { get; set; }

        public string SomeData { get; set; }

        public int UserId { get; set; }
        public string EGNId { get; set; }

        public User User { get; set; }
    }
}
