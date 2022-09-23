using HelpDesk.Employee.Models;
using HelpDesk.Employee.ViewModels;

namespace HelpDesk.Employee.Interfaces
{
    public interface IRequestService
    {
        Task<List<RequestsViewModel>> GetRequests();
        Task<List<CreateRequestModel>> CreateRequest(CreateRequestModel requests);
    }
}
