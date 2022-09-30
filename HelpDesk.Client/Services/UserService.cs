using HelpDesk.Client.Interfaces;
using HelpDesk.Client.ViewModels;
using System.Net.Http.Json;

namespace HelpDesk.Client.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UsersViewModel>> GetUsers()
        {
            return await _httpClient.GetFromJsonAsync<List<UsersViewModel>>("api/user");
        }
    }
}
