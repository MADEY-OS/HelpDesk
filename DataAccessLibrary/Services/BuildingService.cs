using AutoMapper;
using DataAccessLibrary.Data;
using DataAccessLibrary.Entities;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Services;

public class BuildingService : IBuildingService
{
    private readonly HelpDeskDbContext _dbContext;
    private readonly IMapper _mapper;

    public BuildingService(HelpDeskDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public IEnumerable<BuildingDto> GetAll()
    {
        var buildings = _dbContext.Buildings.ToList();
        var buildingsDtos = _mapper.Map<List<BuildingDto>>(buildings);

        return buildingsDtos;
    }

    public BuildingDto GetById(int id)
    {
        var building = _dbContext.Buildings.FirstOrDefault(b => b.Id == id);

        if (building is null) return null;

        var result = _mapper.Map<BuildingDto>(building);

        return result;
    }

    public int Create(CreateBuildingDto dto)
    {
        var building = _mapper.Map<Building>(dto);

        _dbContext.Buildings.Add(building);
        _dbContext.SaveChanges();

        return building.Id;
    }

    public bool Delete(int id)
    {
        var building = _dbContext.Buildings.FirstOrDefault(b => b.Id == id);

        if (building is null) return false;

        _dbContext.Buildings.Remove(building);
        _dbContext.SaveChanges();

        return true;
    }

    public bool Update(int id, CreateBuildingDto dto)
    {
        var building = _dbContext.Buildings.FirstOrDefault(b => b.Id == id);

        if (building is null) return false;
            
        building.Name = dto.Name;

        building.Description = dto.Description;

        _dbContext.SaveChanges();

        return true;
    }
}