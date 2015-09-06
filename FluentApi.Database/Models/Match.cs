using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi.Database
{
    public class Match
    {
        public int Id { get; set; }

        public string Stadium { get; set; }

        public byte[] TimeStamp { get; set; }

        public int Crowd { get; set; }

        public int YellowCards { get; set; }

        public int RedCards { get; set; }

        public DateTime Date { get; set; }
    }
}
