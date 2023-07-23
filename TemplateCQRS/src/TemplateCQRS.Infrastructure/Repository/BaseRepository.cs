namespace TemplateCQRS.Infrastructure.Repository
{
    using System.Data;
    using System.Data.SqlClient;

    public class BaseRepository
    {
        protected readonly SqlConnection SqlConnection;
        protected readonly IDbTransaction DbTransaction;

        protected BaseRepository(SqlConnection sqlConnection, IDbTransaction dbTransaction)
        {
            this.SqlConnection = sqlConnection;
            this.DbTransaction = dbTransaction;
        }
    }
}

