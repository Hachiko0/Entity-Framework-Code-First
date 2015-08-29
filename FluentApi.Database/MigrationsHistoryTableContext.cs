using System.Data.Common;
using System.Data.Entity.Migrations.History;

namespace FluentApi.Database
{
    public class MigrationsHistoryTableContext : HistoryContext
    {
        public MigrationsHistoryTableContext(DbConnection dbConnection, string defaultSchema)
            :base(dbConnection, defaultSchema)
        {

        }
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.HasDefaultSchema("admin");
            modelBuilder.Entity<HistoryRow>().ToTable("MigrationHistory", "admin");
        }
    }
}
