namespace TemplateCQRS.Application.Features.Queries.GetSaleOrders
{
    using AutoMapper;
    using TemplateCQRS.Application.Abstractions.Messaging;
    using TemplateCQRS.Domain.Repository;

    public class GetSaleOrderHandler : IQueryHandler<GetSaleOrderQuery, List<GetSaleOrderResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSaleOrderHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<List<GetSaleOrderResult>> Handle(GetSaleOrderQuery request, CancellationToken cancellationToken)
        {
            var saleOrder = await this._unitOfWork.SaleOrderRepository.GetAllSaleOrder();
            var pagedResult = this._mapper.Map<List<GetSaleOrderResult>>(saleOrder);
            return pagedResult;
        }
    }
}

