namespace BidderServer.Model.Bid;

public class NotifyRequestModel
{
    public string session_id { get; set; }

    public string request_id { get; set; }

    public decimal clear_price { get; set; }
}

