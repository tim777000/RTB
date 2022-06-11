using ExchangeServer.Application;
using ExchangeServer.Infra.Core.Extensions;
using ExchangeServer.Model;
using ExchangeServer.Model.Bid;
using ExchangeServer.Model.Session;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeServer.Api.Controllers;

[Produces("application/json")]
[Route("[Action]")]
[ApiController]
public class ExchangeController : ControllerBase
{
    private readonly ExchangeAppService _exchangeAppService;

    public ExchangeController(ExchangeAppService exchangeAppService)
    {
        _exchangeAppService = exchangeAppService;
    }

    [HttpPost]
    public async Task<IActionResult> bid_request(BidReqRequestModel request)
    {
        try
        {
            var response = await _exchangeAppService.Bid(request);
            return Content(response.SerializeJson());
        }
        catch (Exception ex)
        {
            var response = new BadReqResponseModel() { error = ex.Message };
            return Content(response.SerializeJson());
        }
    }

    [HttpPost]
    public async Task<IActionResult> init_session(SessionInitRequestModel request)
    {
        try
        {
            var response = await _exchangeAppService.SessionOpen(request);
            return Content(response.SerializeJson());
        }
        catch (Exception ex)
        {
            var response = new BadReqResponseModel() { error = ex.Message };
            return Content(response.SerializeJson());
        }
    }

    [HttpPost]
    public async Task<IActionResult> end_session(SessionEndRequestModel request)
    {
        try
        {
            var response = await _exchangeAppService.SessionClose(request);
            return Content(response.SerializeJson());
        }
        catch (Exception ex)
        {
            var response = new BadReqResponseModel() { error = ex.Message };
            return Content(response.SerializeJson());
        }
    }
}
