using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;

namespace BookManager.DAL
{
    public class DefaultDbConfig : DbConfiguration
    {
        public DefaultDbConfig()
        {
            //SetExecutionStrategy("System.Data.SqlClient", () => new SqlConnectionFactory("") );
            SetDefaultConnectionFactory(new LocalDbConnectionFactory("v11.0"));
        }
    }
}
