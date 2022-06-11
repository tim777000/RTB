namespace ExchangeServer.Model.Bid;

public class BidReqRequestModel
{
    /// <summary>
    /// 出價
    /// </summary>
    public decimal floor_price { get; set; }

    /// <summary>
    /// timeout
    /// </summary>
    public int timeout_ms { get; set; }

    /// <summary>
    /// 該次出價session_id
    /// </summary>
    public string session_id { get; set; }

    /// <summary>
    /// 出價者user_id
    /// </summary>
    public string user_id { get; set; }

    /// <summary>
    /// 該次請求id
    /// </summary>
    public string request_id { get; set; }
}

