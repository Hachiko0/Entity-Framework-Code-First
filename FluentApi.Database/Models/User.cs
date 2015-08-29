using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi.Database
{
    public class User
    {
        public int Id { get; set; }

        public string EGN { get; set; }

        public string FirstName { get; set; }

        public string FamilyName { get; set; }

        public Address Address { get; set; }
    }
}
