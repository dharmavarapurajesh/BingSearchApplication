using System;
using System.Net.Http;
using System.Threading.Tasks;

public class BingSearchService
{
    private readonly HttpClient _httpClient;

    public BingSearchService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<string> SearchAsync(string query)
    {
        try
        {
            var url = $"https://api.bing.microsoft.com/v7.0/search?q={Uri.EscapeDataString(query)}";
            var apiKey = "7f5a827efeaf4791b370b23fe720179c";
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
            var response = await _httpClient.GetStringAsync(url);
            return response;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
}
