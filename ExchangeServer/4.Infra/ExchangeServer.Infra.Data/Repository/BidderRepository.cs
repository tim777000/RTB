using ExchangeServer.Model.Session;

namespace ExchangeServer.Infra.Data.Repository;

public class BidderRepository
{
    private readonly Dictionary<string, List<BidderModel>> _bidderDict;

    public BidderRepository()
    {
        _bidderDict = new Dictionary<string, List<BidderModel>>();
    }

    public List<BidderModel> GetSession(string sessionID)
    {
        return _bidderDict[sessionID];
    }

    public void AddSession(string sessionID, List<BidderModel> bidders)
    {
        _bidderDict.Add(sessionID, bidders);
    }

    public void DeleteSession(string sessionID)
    {
        _bidderDict.Remove(sessionID);
    }
}

