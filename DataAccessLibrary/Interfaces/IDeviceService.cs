using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Interfaces
{
    public interface IDeviceService
    {
        DeviceDto GetById(int id);
        IEnumerable<DeviceDto> GetAll();
        int Create(CreateDeviceDto dto);
        bool Delete(int id);
        bool Update(int id, CreateDeviceDto dto);
    }
}
