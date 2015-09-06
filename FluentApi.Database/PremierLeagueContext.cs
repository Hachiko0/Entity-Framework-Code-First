using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;

namespace FluentApi.Database
{
    public class PremierLeagueContext : DbContext
    {
        public PremierLeagueContext()
            : base("PremierLeagueDbContext")
        {
            System.Data.Entity.Database.SetInitializer<PremierLeagueContext>(new DropCreateDatabaseIfModelChanges<PremierLeagueContext>());
            //System.Data.Entity.Database.SetInitializer<PremierLeagueContext>(new MigrateDatabaseToLatestVersion<PremierLeagueContext, FluentApi.Database.Migrations.Configuration>());
            //System.Data.Entity.Database.SetInitializer<PremierLeagueContext>(new DropCreateDatabaseAlways<PremierLeagueContext>());
        }
        public virtual IDbSet<Team> Teams { get; set; }
        public virtual IDbSet<Player> Players { get; set; }
        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<Referee> Refrees { get; set; }

        public virtual IDbSet<Match> Matches { get; set; }

        public virtual IDbSet<League> Leagues { get; set; }

        public virtual IDbSet<Employee> Employees { get; set; }

        //public virtual IDbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //set the default schema for all our tables
            //modelBuilder.HasDefaultSchema("notDbo");

            //make the model to be a complex type, not an entity and set some rules
            modelBuilder
                .ComplexType<Address>()
                .Property(a => a.Stret)
                .HasMaxLength(22);

            //modelBuilder
            //    .Entity<User>()
            //    .Property(u => u.Address.Town)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);


            //DatabaseGeneratedOption
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            //ignore an entity
            modelBuilder.Ignore<Referee>();

            //overload
            //modelBuilder.Ignore(typeof(Referee)); 

            modelBuilder
                .Entity<Team>()
                .HasKey(t => t.TeamPrimmaryKey);

            //if using existing store procedure and the name of the property is different from our code first
            modelBuilder
                .Entity<Team>()
                .Property(t => t.Name)
                .HasParameterName("Ime");

            //set stadium to nvarchar(30)
            modelBuilder
                .Entity<Match>()
                .Property(t => t.Stadium)
                .HasMaxLength(30);

            //when we update or delete, the match record is filtered by stadium too and throws exception if it different than the current stadium
            modelBuilder
                .Entity<Match>()
                .Property(m => m.Stadium)
                .IsConcurrencyToken();

            //modelBuilder
            //    .Entity<Match>()
            //    .Property(m => m.TimeStamp)
            //    .IsRowVersion();

            //create multi column index
            modelBuilder
                .Entity<Match>()
                .Property(m => m.Date)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute(name: "SomeIndexName", order: 1)));

            modelBuilder
                .Entity<Match>()
                .Property(m => m.Stadium)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute(name: "SomeIndexName", order: 2)));

            modelBuilder.Entity<Match>()
                .HasTableAnnotation("TrackDatabaseChanges", true);

            //ignore a property
            modelBuilder.Entity<Match>().Ignore(t => t.Crowd);

            //HasColumnName, HasColumnOrder, HasColumnType, IsUnicode, 
            modelBuilder
                .Entity<Player>()
                .Property(p => p.LastName)
                .HasColumnName("FamilyName")
                .IsUnicode(false);

            modelBuilder
                .Entity<Player>()
                .Property(p => p.FirstName)
                .HasColumnOrder(7)
                .HasColumnType("varchar");

            //set country to be nchar(66)
            modelBuilder
                .Entity<League>()
                .Property(l => l.Country)
                .IsFixedLength()
                .HasMaxLength(66);

            modelBuilder
                .Entity<League>()
                .Property(l => l.Abbreviation)
                .HasMaxLength(99)
                .HasColumnType("nchar")
                .IsRequired();

            modelBuilder.Entity<League>()
                .Property(l => l.NumberOfTeams)
                .IsOptional();

            //modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            #region Create Custom Convetions
            //create custon conventions
            modelBuilder
                .Properties<double>()
                .Configure(s => s.HasPrecision(18, 2));

            //modelBuilder
            //    .Properties<string>()
            //    .Configure(c => c.HasColumnType("varchar"));

            modelBuilder
                .Properties<Guid>()
                .Where(p => p.Name.EndsWith("PrimaryKey"))
                .Configure(p => p.IsKey());

            modelBuilder
                .Properties()
                .Where(p => p.Name.Length > 2 && p.Name.EndsWith("Id"))
                .Configure(c =>
                {
                    string propertyName = c.ClrPropertyInfo.Name;
                    string propertyNameWithoutId = propertyName.Substring(0, propertyName.Length - 2);
                    c.HasColumnName(propertyNameWithoutId + "FKId");
                });

            modelBuilder
                .Types<Player>()
                .Configure(c => c.ToTable(c.ClrType.Name, "PLayerSchema"));

            //remove built-in conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Conventions.AddBefore<ComplexTypeDiscoveryConvention>(new DateTime2Convention());
            #endregion
        }
    }
    public class DateTime2Convention : Convention
    {
        public DateTime2Convention()
        {
            this.Properties<DateTime>()
                .Configure(c => c.HasColumnType("datetime2"));
        }
    }

    public class LeagueConfiguration : EntityTypeConfiguration<League>
    {
        public LeagueConfiguration()
        {
            this
                .Property(l => l.Country)
                .IsFixedLength()
                .HasMaxLength(66);

            this
                .Property(l => l.Abbreviation)
                .HasMaxLength(99)
                .HasColumnType("nchar")
                .IsRequired();

            this
                .Property(l => l.NumberOfTeams)
                .IsOptional();
        }
    }
}
