namespace ExchangeServer.Model.BidderServer.Bid;

public class BidderServerBidReqResponseModel
{
    public string session_id { get; set; }

    public string request_id { get; set; }

    public decimal price { get; set; }

    public string name { get; set; }
}

