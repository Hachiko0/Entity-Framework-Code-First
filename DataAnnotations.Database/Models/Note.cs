using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAnnotations.Database
{
    public class Note
    {
        [Column(Order = 0)]
        public int Id { get; set; }

        [MaxLength(200)]
        [Column("Data", TypeName = "varchar")]
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
