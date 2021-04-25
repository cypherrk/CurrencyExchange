using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OctetWebApi.Biz.Markup.Commands.CreateMarkup;
using OctetWebApi.Biz.Markup.Queries.GetMarkupQuery;
using System.Threading.Tasks;

namespace OctetWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyExchangeMarkupController : ControllerBase
    {
        private readonly ILogger<CurrencyExchangeMarkupController> _logger;
        private readonly ISender _mediator;

        public CurrencyExchangeMarkupController(ILogger<CurrencyExchangeMarkupController> logger, ISender mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<MarkupsVm> Get()
        {
            return await _mediator.Send(new GetMarkupQuery());
        }

        [HttpPost]
        public async Task<int> CreateMarkup(CreateMarkupCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
