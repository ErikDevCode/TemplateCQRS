namespace TemplateCQRS.Application.Features.Queries.GetSaleOrders
{
    public class GetSaleOrderResult
    {
        public Guid Id { get; set; }

        public Guid ProviderSaleOrderId { get; set; }

        public string OrderNumber { get; set; }

        public string Source { get; set; }

        public int ProviderStatus { get; set; }

        public string ProviderStatusName { get; set; }

        public int Status { get; set; }

        public string StatusName { get; set; }
    }
}

