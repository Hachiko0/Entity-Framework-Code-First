using DataAnnotations.Database.Models;
using System.Data.Entity;

namespace DataAnnotations.Database
{
    public class PremierLeagueContext : DbContext
    {
        public PremierLeagueContext()
            : base("PremierLeagueDbContext")
        {
            //System.Data.Entity.Database.SetInitializer<PremierLeagueContext>(new MigrateDatabaseToLatestVersion<PremierLeagueContext, Configuration>());
            //System.Data.Entity.Database.SetInitializer<PremierLeagueContext>(new DropCreateDatabaseAlways<PremierLeagueContext>());
        }
        public virtual IDbSet<Team> Teams { get; set; }
        public virtual IDbSet<Player> Players { get; set; }

        public virtual IDbSet<Match> Matches { get; set; }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Referee> Referees { get; set; }

        public virtual IDbSet<Address> Addresses { get; set; }

        public virtual IDbSet<UserForeignKey> UserForeignKey { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
