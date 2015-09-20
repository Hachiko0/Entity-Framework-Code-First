using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ConfigureMappings.Database
{
    public class MyInitializer : DropCreateDatabaseIfModelChanges<PremierLeagueContext>
    {
        public override void InitializeDatabase(PremierLeagueContext context)
        {
            //context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
            //    , string.Format("ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

            base.InitializeDatabase(context);
        }
    }
    public class PremierLeagueContext : DbContext
    {
        public PremierLeagueContext()
            : base("PremierLeagueDbContext")
        {
            //System.Data.Entity.Database.SetInitializer(new MyInitializer());
            //System.Data.Entity.Database.SetInitializer<PremierLeagueContext>(new DropCreateDatabaseIfModelChanges<PremierLeagueContext>());
            //System.Data.Entity.Database.SetInitializer<PremierLeagueContext>(new MigrateDatabaseToLatestVersion<PremierLeagueContext, ConfigureMappings.Database.Migrations.Configuration>());
            //System.Data.Entity.Database.SetInitializer<PremierLeagueContext>(new DropCreateDatabaseAlways<PremierLeagueContext>());
        }

        public virtual IDbSet<Team> Teams { get; set; }
        public virtual IDbSet<Player> Players { get; set; }
        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<League> Leagues { get; set; }

        public virtual IDbSet<PlayerAddress> PlayerAddress { get; set; }

        public virtual IDbSet<UserForeignKey> UserForeignKey { get; set; }

        public virtual IDbSet<Employee> Employees { get; set; }

        public virtual IDbSet<Referee> Referees { get; set; }

        public virtual IDbSet<Coach> Coaches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //one-to-zero-or-one

            //map the primary key because it does not follow the conventions
            modelBuilder.Entity<PlayerAddress>()
                .HasKey(pa => pa.PlayerId);

            //map one-to-zero-or-one
            modelBuilder.Entity<PlayerAddress>()
                .HasRequired(pa => pa.Player)
                .WithOptional(p => p.Address);

            //the other way around
            //modelBuilder.Entity<Player>()
            //    .HasOptional(p => p.Address)
            //    .WithRequired(pa => pa.Player);

            //map one-to-one
            //modelBuilder.Entity<PlayerAddress>()
            //    .HasRequired(pa => pa.Player)
            //    .WithRequiredPrincipal(p => p.Address);

            //the other way around
            //modelBuilder.Entity<Player>()
            //    .HasRequired(p => p.Address)
            //    .WithRequiredDependent(pa => pa.Player);

            //one-to-many
            modelBuilder
                .Entity<Player>()
                .HasOptional(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId)
                .WillCascadeOnDelete(false);

            //one table having two foreign keys from the same table(Match has HomeTeam and AwayTeam)
            modelBuilder
                .Entity<Match>()
                .HasOptional(m => m.HomeTeam)
                .WithMany(t => t.HomeMatches)
                .HasForeignKey(m => m.HomeTeamId)
                .WillCascadeOnDelete(false);

            modelBuilder
                .Entity<Match>()
                .HasRequired(m => m.AwayTeam)
                .WithMany(t => t.AwayMatches)
                .HasForeignKey(m => m.AwayTeamId)
                .WillCascadeOnDelete(false);

            //many-to-many
            modelBuilder
                .Entity<Team>()
                .HasMany(t => t.Leagues)
                .WithMany(l => l.Teams)
                .Map(m =>
                {
                    m.ToTable("LeagueTeam");
                    m.MapLeftKey("LeagueId");
                    m.MapRightKey("TeamId");
                });

            //self-referrence one-to-many
            modelBuilder
                .Entity<Player>()
                .HasOptional(p => p.Substitute)
                .WithMany(p => p.Substitues)
                .HasForeignKey(p => p.SubstituteId);

            //self reference many-to-many
            modelBuilder
                .Entity<Employee>()
                .HasMany(e => e.EmployeesILike)
                .WithMany(p => p.EmployeesThatLikeMe)
                .Map(m =>
                {
                    m.MapLeftKey("EmployeeId");
                    m.MapRightKey("OtherEmployeeId");
                    m.ToTable("EmplooyeLikers");
                });


            //Composite key as foreign key

            //map the primary key 
            modelBuilder
                .Entity<User>()
                .HasKey(t => new { t.Id, t.EGN });

            //map the foreign key
            modelBuilder
                .Entity<UserForeignKey>()
                .HasRequired(ufk => ufk.User)
                .WithMany(t => t.UserForeignKeys)
                .HasForeignKey(utf => new { utf.UserId, utf.EGNId });

            //inheritance
            modelBuilder.Entity<Referee>()
                .ToTable("Referees");

            modelBuilder.Entity<Coach>()
                .ToTable("Coaches");

            //table splitting
            //split 1 table into two separate entities(classes)
            modelBuilder
                .Entity<PlayerPhoto>()
                .HasKey(pp => pp.PlayerId);

            modelBuilder
                .Entity<PlayerPhoto>()
                .ToTable("Players");

            modelBuilder
                .Entity<Player>()
                .ToTable("Players");

            modelBuilder.Entity<Player>()
                .HasRequired(p => p.Photo)
                .WithRequiredDependent();
        }
    }
}
