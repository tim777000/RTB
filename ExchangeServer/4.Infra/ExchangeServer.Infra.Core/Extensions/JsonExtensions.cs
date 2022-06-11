using System.Text.Json;

namespace ExchangeServer.Infra.Core.Extensions;

public static class JsonExtensions
{
    public static string SerializeJson(this object model)
    {
        return JsonSerializer.Serialize(model);
    }
}

