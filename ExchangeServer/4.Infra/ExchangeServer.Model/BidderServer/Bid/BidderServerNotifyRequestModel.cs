namespace ExchangeServer.Model.BidderServer.Bid;

public class BidderServerNotifyRequestModel
{
    public string session_id { get; set; }

    public string request_id { get; set; }

    public decimal clear_price { get; set; }
}

