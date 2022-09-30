using DataAccessLibrary.Models;

namespace DataAccessLibrary.Interfaces
{
    public interface IDeviceService
    {
        DeviceDto GetById(int id);
        IEnumerable<DetailedDeviceDto> GetAll();
        int Create(CreateDeviceDto dto);
        bool Delete(int id);
        bool Update(int id, CreateDeviceDto dto);
    }
}
