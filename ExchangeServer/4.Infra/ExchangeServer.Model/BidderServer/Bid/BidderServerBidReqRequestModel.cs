namespace ExchangeServer.Model.BidderServer.Bid;

public class BidderServerBidReqRequestModel
{
    public decimal floor_price { get; set; }

    public int timeout_ms { get; set; }

    public string session_id { get; set; }

    public string user_id { get; set; }

    public string request_id { get; set; }
}

