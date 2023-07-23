namespace TemplateCQRS.Infrastructure.Repository
{
    using System.Data;
    using System.Data.SqlClient;
    using Dapper;
    using TemplateCQRS.Domain.Entities;
    using TemplateCQRS.Domain.Repository;

    public class SaleOrderRepository : BaseRepository, ISaleOrderRepository
    {
        public SaleOrderRepository(SqlConnection sqlConnection, IDbTransaction dbTransaction)
            : base(sqlConnection, dbTransaction)
        {
        }

        public async Task<List<SaleOrder>> GetAllSaleOrder()
        {
            const string sqlQuery = @"SELECT Id, ProviderSaleOrderId, OrderNumber, Source, ProviderStatus, ProviderStatusName, Status, StatusName  FROM SaleOrders";

            var response = await this.SqlConnection.QueryAsync<SaleOrder>(sqlQuery,
                 transaction: this.DbTransaction);

            return response.ToList();
        }
    }
}

