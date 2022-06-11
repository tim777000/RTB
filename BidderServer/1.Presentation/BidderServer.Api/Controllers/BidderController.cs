using BidderServer.Application;
using BidderServer.Infra.Core.Extensions;
using BidderServer.Model;
using BidderServer.Model.Bid;
using BidderServer.Model.Session;
using Microsoft.AspNetCore.Mvc;

namespace BidderServer.Api.Controllers;

[Produces("application/json")]
[Route("[Action]")]
[ApiController]
public class BidderController : ControllerBase
{
    private readonly BidderAppService _bidderAppService;

    public BidderController(BidderAppService bidderAppService)
    {
        _bidderAppService = bidderAppService;
    }

    [HttpPost]
    public async Task<IActionResult> bid_request(BidReqRequestModel request)
    {
        try
        {
            var response = await _bidderAppService.Bid(request);
            return Content(response.SerializeJson());
        }
        catch (Exception ex)
        {
            var response = new BadReqResponseModel() { error = ex.Message };
            return Content(response.SerializeJson());
        }
    }

    [HttpPost]
    public async Task<IActionResult> notify_win_bid(NotifyRequestModel request)
    {
        try
        {
            var response = await _bidderAppService.Notify(request);
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
            var response = await _bidderAppService.SessionOpen(request);
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
            var response = await _bidderAppService.SessionClose(request);
            return Content(response.SerializeJson());
        }
        catch (Exception ex)
        {
            var response = new BadReqResponseModel() { error = ex.Message };
            return Content(response.SerializeJson());
        }
    }
}

