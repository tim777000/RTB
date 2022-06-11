using ExchangeServer.Infra.Core.Extensions;
using ExchangeServer.Infra.Data.Repository;
using ExchangeServer.Model.Bid;
using ExchangeServer.Model.BidderServer.Bid;
using ExchangeServer.Model.BidderServer.Session;
using ExchangeServer.Model.Enum;
using ExchangeServer.Model.Session;

namespace ExchangeServer.Application;

public class ExchangeAppService
{
    private readonly HttpClientRepository _httpClientRepository;
    private readonly BidderRepository _bidderRepository;

    public ExchangeAppService(
        HttpClientRepository httpClientRepository,
        BidderRepository bidderRepository)
    {
        _httpClientRepository = httpClientRepository;
        _bidderRepository = bidderRepository;
    }

    public async Task<BidReqResponseModel> Bid(BidReqRequestModel request)
    {
        var bidderReqModel = new BidderServerBidReqRequestModel()
        {
            floor_price = request.floor_price,
            timeout_ms = request.timeout_ms,
            session_id = request.session_id,
            user_id = request.user_id,
            request_id = request.request_id,
        };

        var bidders = _bidderRepository.GetSession(request.session_id);

        List<BidderServerBidReqResponseModel> responses = new List<BidderServerBidReqResponseModel>();

        foreach (var bidder in bidders)
        {
            var response = await _httpClientRepository.SendAsync<BidderServerBidReqResponseModel>(bidderReqModel.SerializeJson(), bidder.endpoint, "bid_request", request.timeout_ms);
            response.name = bidder.name;
            responses.Add(response);
        }

        List<BidModel> bid_responses = new List<BidModel>();

        foreach (var response in responses)
        {
            var bid_response = new BidModel()
            {
                name = response.name,
                price = response.price,
            };
            bid_responses.Add(bid_response);
        }

        var winner = new BidModel();

        var repGroup = bid_responses.GroupBy(rep => rep.price);
        var maxRep = repGroup.Where(group => group.Key == repGroup.Max(x => x.Key)).SelectMany(group => group);

        if (maxRep.Count() == 1)
        {
            winner.name = maxRep.FirstOrDefault().name;
            winner.price = maxRep.FirstOrDefault().price;
        }

        return new BidReqResponseModel()
        {
            session_id = request.session_id,
            request_id = request.request_id,
            win_bid = winner,
            bid_response = bid_responses
        };
    }

    public async Task<SessionResponseModel> SessionOpen(SessionInitRequestModel request)
    {
        var bidderReqModel = new BidderServerSessionInitRequestModel()
        {
            session_id = request.session_id,
            estimated_traffic = request.estimated_traffic,
            budget = request.bidder_settings.budget,
            impression_goal = request.bidder_settings.impression_goal
        };

        _bidderRepository.AddSession(request.session_id, request.bidders);

        foreach (var bidder in request.bidders)
        {
            await _httpClientRepository.SendAsync<BidderServerSessionResponse>(bidderReqModel.SerializeJson(), bidder.endpoint, "init_session");
        }

        return new SessionResponseModel()
        {
            result = ResultEnum.ok
        };
    }

    public async Task<SessionResponseModel> SessionClose(SessionEndRequestModel request)
    {
        var bidderReqModel = new BidderServerSessionEndRequestModel()
        {
            session_id = request.session_id,
        };

        var bidders = _bidderRepository.GetSession(request.session_id);

        foreach (var bidder in bidders)
        {
            await _httpClientRepository.SendAsync<BidderServerSessionResponse>(bidderReqModel.SerializeJson(), bidder.endpoint, "end_session");
        }

        return new SessionResponseModel()
        {
            result = ResultEnum.ok
        };
    }
}

