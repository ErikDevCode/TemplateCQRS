namespace TemplateCQRS.Infrastructure.Repository
{
    using System.Data;
    using TemplateCQRS.Domain.Repository;

    public class UnitOfWork : IUnitOfWork
    {
        public ISaleOrderRepository SaleOrderRepository { get; }

        private readonly IDbTransaction _dbTransaction;


        public UnitOfWork(IDbTransaction dbTransaction, ISaleOrderRepository saleOrderRepository)
        {
            this._dbTransaction = dbTransaction;
            this.SaleOrderRepository = saleOrderRepository;
        }

        public void SaveChanges()
        {
            try
            {
                this._dbTransaction.Commit();
                this._dbTransaction.Connection?.BeginTransaction();
            }
            catch (Exception)
            {
                this._dbTransaction.Rollback();
                throw;
            }
        }

        public void Dispose()
        {
            this._dbTransaction.Connection?.Close();
            this._dbTransaction.Connection?.Dispose();
            this._dbTransaction.Dispose();
        }
    }
}

