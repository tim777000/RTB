namespace ExchangeServer.Model.BidderServer.Session;

public class BidderServerSessionInitRequestModel
{
    public string session_id { get; set; }

    public int estimated_traffic { get; set; }

    public decimal budget { get; set; }

    public int impression_goal { get; set; }
}

