namespace TemplateCQRS.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();

        ISaleOrderRepository SaleOrderRepository { get; }
    }
}