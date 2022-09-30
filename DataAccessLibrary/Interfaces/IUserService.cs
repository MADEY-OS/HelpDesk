using DataAccessLibrary.Models;

namespace DataAccessLibrary.Interfaces
{
    public interface IUserService
    {
        IEnumerable<DetailedUserDto> GetAll();
        UserDto GetById(int id);
        int Create(CreateUserDto dto);
        bool Delete(int id);
        bool Update(int id, CreateUserDto dto);
    }
}
