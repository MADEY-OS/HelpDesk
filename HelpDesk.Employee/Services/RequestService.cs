using System.Net.Http.Json;
using HelpDesk.Employee.Interfaces;
using HelpDesk.Employee.Models;
using HelpDesk.Employee.ViewModels;

namespace HelpDesk.Employee.Services
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

        public async Task<List<CreateRequestModel>> CreateRequest(CreateRequestModel request)
        {
            var result =  await _httpClient.PostAsJsonAsync($"api/request", request);

            var requests = await result.Content.ReadFromJsonAsync<List<CreateRequestModel>>();

            return requests;
        }

    }
}
