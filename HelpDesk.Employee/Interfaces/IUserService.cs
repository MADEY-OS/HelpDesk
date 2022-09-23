using HelpDesk.Employee.ViewModels;

namespace HelpDesk.Employee.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetUser(int id);
    }
}
