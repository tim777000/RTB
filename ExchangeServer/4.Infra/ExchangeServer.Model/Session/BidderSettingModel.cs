namespace ExchangeServer.Model.Session;

public class BidderSettingModel
{
    /// <summary>
    /// 該次競標最低價
    /// </summary>
    public decimal budget { get; set; }

    /// <summary>
    /// 得標者會得到多少競標品
    /// </summary>
    public int impression_goal { get; set; }
}

