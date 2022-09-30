using DataAccessLibrary.Models;

namespace DataAccessLibrary.Interfaces;

public interface IRequestService
{
    IEnumerable<DetailedRequestDto> GetAll();
    DetailedRequestDto GetById(int id);
    int Create(CreateRequestDto gto);
    bool Delete(int id);
    bool Update(int id, CreateRequestDto dto);
}