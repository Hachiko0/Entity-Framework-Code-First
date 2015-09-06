using System.ComponentModel.DataAnnotations.Schema;

namespace DataAnnotations.Database.Models
{
    public class Referee
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string FullName { get; set; }
    }
}
