using HelpDesk.Client.ViewModels;

namespace HelpDesk.Client.Interfaces
{
    public interface IRequestService
    {
        Task<List<RequestsViewModel>> GetRequests();
        Task<RequestsViewModel> GetRequest(int id);
        Task<int> DeleteRequest(int id);
    }
}
