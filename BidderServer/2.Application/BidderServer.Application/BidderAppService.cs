using BidderServer.Infra.Data.Repository;
using BidderServer.Model;
using BidderServer.Model.Bid;
using BidderServer.Model.Enum;
using BidderServer.Model.Session;

namespace BidderServer.Application;

public class BidderAppService
{
    private readonly SessionRepository _sessionRepository;

    public BidderAppService(SessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task<BidReqResponseModel> Bid(BidReqRequestModel request)
    {
        var session = _sessionRepository.GetSession(request.session_id);

        Random random = new Random();
        var price = Convert.ToDecimal(random.NextDouble()*(decimal.ToDouble(session.budget)- decimal.ToDouble(request.floor_price)) + decimal.ToDouble(request.floor_price));

        return new BidReqResponseModel()
        {
            session_id = request.session_id,
            request_id = request.request_id,
        };
    }

    public async Task<ResultResponseModel> Notify(NotifyRequestModel request)
    {
        return new ResultResponseModel()
        {
            result = ResultEnum.ok
        };
    }

    public async Task<ResultResponseModel> SessionOpen(SessionInitRequestModel request)
    {
        _sessionRepository.AddSession(request.session_id, request);

        return new ResultResponseModel()
        {
            result = ResultEnum.ok
        };
    }

    public async Task<ResultResponseModel> SessionClose(SessionEndRequestModel request)
    {
        _sessionRepository.DeleteSession(request.session_id);

        return new ResultResponseModel()
        {
            result = ResultEnum.ok
        };
    }
}

