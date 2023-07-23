namespace TemplateCQRS.Domain.Repository
{
    using TemplateCQRS.Domain.Entities;

    public interface ISaleOrderRepository
    {
        Task<List<SaleOrder>> GetAllSaleOrder();
    }
}
