namespace TemplateCQRS.Domain.Entities
{
    public class SaleOrder
    {
        public Guid Id { get; set; }

        public Guid ProviderSaleOrderId { get; set; }

        public int ProviderStatus { get; set; }

        public string ProviderStatusName { get; set; }

        public int Status { get; set; }

        public string StatusName { get; set; }
    }
}

