namespace BidderServer.Model.Bid;

public class BidReqResponseModel
{
    public string session_id { get; set; }

    public string request_id { get; set; }

    public decimal price { get; set; }
}

