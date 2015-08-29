using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace FluentApi.Database
{
    internal class CustomDbConfiguration : DbConfiguration
    {
        public CustomDbConfiguration()
        {
            this.SetHistoryContext(SqlProviderServices.ProviderInvariantName, 
                (connection, defaultSchema) => new MigrationsHistoryTableContext(connection, defaultSchema));
        }
    }
}
