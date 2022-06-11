using System.Text.Json;

namespace BidderServer.Infra.Core.Extensions;
public static class JsonExtensions
{
    public static string SerializeJson(this object model)
    {
        return JsonSerializer.Serialize(model);
    }
}