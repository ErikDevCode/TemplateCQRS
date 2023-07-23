namespace TemplateCQRS.Application.Mappings
{
    using AutoMapper;
    using TemplateCQRS.Application.Features.Queries.GetSaleOrders;
    using TemplateCQRS.Domain.Entities;

    public class SaleOrderProfile : Profile
    {
        public SaleOrderProfile()
        {
            this.CreateMap(typeof(SaleOrder), typeof(GetSaleOrderResult));
        }
    }
}

