using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi.Database
{
    public class Address
    {
        public int Id { get; set; }
        public string Town { get; set; }

        public string Stret { get; set; }

        public string ZipCode { get; set; }
    }
}
