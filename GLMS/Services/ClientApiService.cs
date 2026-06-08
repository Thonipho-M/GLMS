using GLMS.Shared.DTOs;
using System.Net.Http.Json;
using GLMS.Shared.Requests;

public class ClientApiService
{
    private readonly HttpClient _http;

    public ClientApiService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("GLMSAPI");
    }

    public async Task<List<ClientDto>> GetClients()
    {
        return await _http.GetFromJsonAsync<List<ClientDto>>("api/clients");
    }

    public async Task CreateClient(CreateClientRequest request)
    {
        await _http.PostAsJsonAsync("api/clients", request);
    }
}