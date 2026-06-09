using GLMS.Models.ViewModels;
using System.Net.Http.Json;

namespace GLMS.Web.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;

        public ApiService(HttpClient http)
        {
            _http = http;
        }

        // CONTRACTS
        public async Task<List<ContractViewModel>> GetContracts()
        {
            return await _http.GetFromJsonAsync<List<ContractViewModel>>("api/contracts");
        }

        // SERVICE REQUESTS
        public async Task<List<ServiceRequestViewModel>> GetServiceRequests()
        {
            return await _http.GetFromJsonAsync<List<ServiceRequestViewModel>>("api/servicerequests");
        }

        public async Task CreateServiceRequest(CreateServiceRequestViewModel model)
        {
            await _http.PostAsJsonAsync("api/servicerequests", model);
        }
    }
}