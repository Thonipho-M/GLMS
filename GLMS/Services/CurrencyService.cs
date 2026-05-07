
using System.Text.Json;

public class CurrencyService
{
    private readonly HttpClient _httpClient;

    public CurrencyService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<decimal> GetUsdToZarRateAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("https://open.er-api.com/v6/latest/USD");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            using var json = JsonDocument.Parse(content);
            var rate = json.RootElement
                           .GetProperty("rates")
                           .GetProperty("ZAR")
                           .GetDecimal();

            return rate;
        }
        catch
        {
            // fallback if API fails
            return 18.50m;
        }
    }

    public decimal ConvertUsdToZar(decimal usd, decimal rate)
    {
        return usd * rate;
    }
}