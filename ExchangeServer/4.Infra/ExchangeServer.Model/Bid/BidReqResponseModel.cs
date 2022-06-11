namespace ExchangeServer.Model.Bid;

public class BidReqResponseModel
{
    /// <summary>
    /// 該次出價session_id，同request內容
    /// </summary>
    public string session_id { get; set; }

    /// <summary>
    /// 該次請求id，同request內容
    /// </summary>
    public string request_id { get; set; }

    /// <summary>
    /// 得標者
    /// </summary>
    public BidModel win_bid { get; set; }

    /// <summary>
    /// 全出價者訊息
    /// </summary>
    public List<BidModel> bid_response { get; set; }
}

