using System.Text;
using System.Text.Json;

namespace ExchangeServer.Infra.Data.Repository;

public class HttpClientRepository
{
    public HttpClientRepository()
    {

    }

    public async Task<T> SendAsync<T>(string postData, string endpoint, string relativeUri, int timeoout = 60000)
    {
        var httpContent = new StringContent(postData, Encoding.UTF8, "application/json");
        var client = new HttpClient() { BaseAddress = new Uri(endpoint), Timeout = TimeSpan.FromMilliseconds(timeoout)};

        var response = await client.PostAsync(relativeUri, httpContent);

        var respBody = await response.Content.ReadAsStringAsync();
        var rsltModel = JsonSerializer.Deserialize<T>(respBody);

        return rsltModel;
    }
}

