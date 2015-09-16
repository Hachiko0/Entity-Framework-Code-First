using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAnnotations.Database
{
    public class Match
    {
        public int Id { get; set; }

        [NotMapped]
        public int NotGonnaBeMaped { get; set; }

        public DateTime Date { get; set; }

        public int HomeTeamId { get; set; }
        
        [ForeignKey("HomeTeamId")]
        public Team HomeTeam { get; set; }
        
        public Team AwayTeam { get; set; }
    }
}
