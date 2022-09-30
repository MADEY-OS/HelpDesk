using HelpDesk.Client.Interfaces;
using HelpDesk.Client.ViewModels;
using System.Net.Http.Json;

namespace HelpDesk.Client.Services
{
    public class RequestService : IRequestService
    {
        private readonly HttpClient _httpClient;

        public RequestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<RequestsViewModel>> GetRequests()
        {
            return await _httpClient.GetFromJsonAsync<List<RequestsViewModel>>("api/request");
        }

        public async Task<RequestsViewModel> GetRequest(int id)
        {
            return await _httpClient.GetFromJsonAsync<RequestsViewModel>($"api/request/{id}");
        }

        public async Task<int> DeleteRequest(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/request/{id}");
            return id;

        }
    }
}
