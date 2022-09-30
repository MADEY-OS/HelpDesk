using HelpDesk.Client.ViewModels;

namespace HelpDesk.Client.Interfaces
{
    public interface IUserService
    {
        Task<List<UsersViewModel>> GetUsers();
    }
}
