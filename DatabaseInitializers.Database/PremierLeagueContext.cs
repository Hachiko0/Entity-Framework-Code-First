using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DatabaseInitializers.Database
{
    public class PremierLeagueContext : DbContext
    {
        public PremierLeagueContext()
            : base("PremierLeagueDbContext")
        {
            //System.Data.Entity.Database.SetInitializer(new CreateDatabaseIfNotExists<PremierLeagueContext>());
            //System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseAlways<PremierLeagueContext>());
            //System.Data.Entity.Database.SetInitializer(new MyInitializer());
            //System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PremierLeagueContext>());
            //System.Data.Entity.Database.SetInitializer<PremierLeagueContext>(new MigrateDatabaseToLatestVersion<PremierLeagueContext, DatabaseInitializers.Database.Migrations.Configuration>());
        }
        public virtual IDbSet<Team> Teams { get; set; }
        public virtual IDbSet<Player> Players { get; set; }
        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<Referee> Refrees { get; set; }
        public virtual IDbSet<League> Leagues { get; set; }
        public virtual IDbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ////set the default schema for all our tables
            //modelBuilder.HasDefaultSchema("notDbo");

            ////make the model to be a complex type, not an entity
            //modelBuilder.ComplexType<Address>();

            ////ignore an entity
            //modelBuilder.Ignore<Referee>();

            ////overload
            ////modelBuilder.Ignore(typeof(Referee)); 

            //modelBuilder.Entity<Team>().HasKey(t => t.TeamPrimmaryKey);
            ////if using existing store procedure and the name of the property is different from our code first
            //modelBuilder.Entity<Team>().Property(t => t.Name).HasParameterName("Ime");
            //modelBuilder.Entity<Match>().Property(t => t.Stadium).HasMaxLength(30);
            
            ////create multi column index
            //modelBuilder.Entity<Match>().Property(m => m.Date).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("SomeIndexName", 1)));
            //modelBuilder.Entity<Match>().Property(m => m.Stadium).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("SomeIndexName", 2)));

            ////ignore a property
            //modelBuilder.Entity<Match>().Ignore(t => t.Crowd);
           
            //modelBuilder.Entity<Player>().Property(p => p.LastName).HasColumnName("FamilyName").IsUnicode(false);
            //modelBuilder.Entity<Player>().Property(p => p.FirstName).HasColumnOrder(7).HasColumnType("varchar");

            ////create custon conventions
            //modelBuilder
            //    .Properties<double>()
            //    .Configure(s => s.HasPrecision(18, 2));

            ////modelBuilder
            ////    .Properties<string>()
            ////    .Configure(c => c.HasColumnType("varchar"));

            //modelBuilder
            //    .Properties<Guid>()
            //    .Where(p => p.Name.EndsWith("PrimaryKey"))
            //    .Configure(p => p.IsKey());

            //modelBuilder
            //    .Properties()
            //    .Where(p => p.Name.Length > 2 && p.Name.EndsWith("Id"))
            //    .Configure(c =>
            //    {
            //        string propertyName = c.ClrPropertyInfo.Name;
            //        string propertyNameWithoutId = propertyName.Substring(0, propertyName.Length - 2);
            //        c.HasColumnName(propertyNameWithoutId + "FKId");
            //    });

            //modelBuilder
            //    .Types<Player>()
            //    .Configure(c => c.ToTable(c.ClrType.Name, "PLayerSchema"));

            ////remove built-in conventions
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            ////modelBuilder.Conventions.AddBefore<ComplexTypeDiscoveryConvention>(new DateTime2Convention());
            //base.OnModelCreating(modelBuilder);
        }
    }
}
