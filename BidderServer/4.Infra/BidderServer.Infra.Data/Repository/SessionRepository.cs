using BidderServer.Model.Session;

namespace BidderServer.Infra.Data.Repository;

public class SessionRepository
{
    private readonly Dictionary<string, SessionInitRequestModel> _sessionDict;

    public SessionRepository()
    {
        _sessionDict = new Dictionary<string, SessionInitRequestModel>();
    }

    public SessionInitRequestModel GetSession(string sessionID)
    {
        return _sessionDict[sessionID];
    }

    public void AddSession(string sessionID, SessionInitRequestModel session)
    {
        _sessionDict.Add(sessionID, session);
    }

    public void DeleteSession(string sessionID)
    {
        _sessionDict.Remove(sessionID);
    }
}

