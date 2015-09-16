
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAnnotations.Database
{
    //[Table("Player", Schema = "admin")]
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        //when we update or delete a player, the record is filtered by last name too and throws exception if it different than the current last name
        //[ConcurrencyCheck]
        public string LastName { get; set; }

        //applied on byte[] only
        //this property is part of the filter just like LastName
        //Every time  a row with a Timestamp column is modified or inserted, the incremented database Timestamp value is inserted in the rowversion column.
        //[Timestamp]
        //public byte[] RowVersion { get; set; }

        public byte[] Avatar { get; set; }

        //[Index("Index_Age", IsClustered = false, IsUnique = false, Order = 0)]
        public int Age { get; set; }

        //[Index("Index_Age", IsClustered = false, IsUnique = false, Order = 1)]
        public int TshirtNumber { get; set; }

        //public int TeamPrimmaryKey { get; set; }

        //public int TeamId { get; set; } //not working(there is no primary key TeamId property in Team) unless we have foreign key attribute for the nav property
        //[ForeignKey("TeamId")]
        public Team Team { get; set; }
    }
}
