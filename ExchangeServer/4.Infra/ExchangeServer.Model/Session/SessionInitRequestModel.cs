namespace ExchangeServer.Model.Session;

public class SessionInitRequestModel
{
    /// <summary>
    /// 該次session_id
    /// </summary>
    public string session_id { get; set; }

    /// <summary>
    /// 預估出價數量
    /// </summary>
    public int estimated_traffic { get; set; }

    /// <summary>
    /// 出價者訊息
    /// </summary>
    public List<BidderModel> bidders { get; set; }

    /// <summary>
    /// 該次競標設定
    /// </summary>
    public BidderSettingModel bidder_settings { get; set; }
}

