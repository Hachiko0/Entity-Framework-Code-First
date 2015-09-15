
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DatabaseInitializers.Database
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} ,Age: {this.Age}";
        }
    }
}
