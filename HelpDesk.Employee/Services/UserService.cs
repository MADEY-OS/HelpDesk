using System.Net.Http.Json;
using HelpDesk.Employee.Interfaces;
using HelpDesk.Employee.ViewModels;

namespace HelpDesk.Employee.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserViewModel> GetUser(int id)
        {
            return await _httpClient.GetFromJsonAsync<UserViewModel>($"api/user/{id}");
        }
    }
}
