using System.ComponentModel.DataAnnotations.Schema;

namespace DataAnnotations.Database
{
    [ComplexType]
    public class Address
    {
        public int Id { get; set; }
        public string Town { get; set; }

        public string Stret { get; set; }

        public string ZipCode { get; set; }
    }
}
