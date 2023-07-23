namespace TemplateCQRS.Presentation.Controllers
{
    using System.Net;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Serilog;
    using TemplateCQRS.Application.Features.Queries.GetSaleOrders;

    [ApiController]
    [Route("[controller]")]
    public class SaleOrderController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public SaleOrderController(ILogger logger, IMediator mediator)
        {
            this._logger = logger;
            this._mediator = mediator;
        }

        [HttpGet]
        [Route("SaleOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetSaleOrder(CancellationToken cancellationToken)
        {
            var result = await this._mediator.Send(new GetSaleOrderQuery(), cancellationToken);
            return this.Ok(result);
        }
    }
}

