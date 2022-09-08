using DataAccessLibrary.Models;

namespace DataAccessLibrary.Interfaces;

public interface IBuildingService
{
    IEnumerable<BuildingDto> GetAll();
    BuildingDto GetById(int id);
    int Create(CreateBuildingDto dto);
    bool Delete(int id);
    bool Update(int id, CreateBuildingDto dto);

}