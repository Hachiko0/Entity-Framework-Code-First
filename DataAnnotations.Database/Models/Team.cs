﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotations.Database
{
    public class Team
    {
        [Key]
        public int TeamPrimmaryKey { get; set; }

        [MaxLength(10)]
        [MinLength(2)]
        public string Name { get; set; }

        public string Division { get; set; }

        public int GoalScored { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }
    }
}
