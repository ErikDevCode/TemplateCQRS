namespace TemplateCQRS.Application.Features.Queries.GetSaleOrders
{
    using TemplateCQRS.Application.Abstractions.Messaging;
    using TemplateCQRS.Application.Commons;

    public class GetSaleOrderQuery : IQuery<List<GetSaleOrderResult>>
    {
    }
}

