using DataAccessLibrary.Models;

namespace DataAccessLibrary.Interfaces;

public interface ICategoryService
{
    IEnumerable<CategoryDto> GetAll();
    CategoryDto GetById(int id);
    int Create(CreateCategoryDto dto);
    bool Delete(int id);
    bool Update(int id, CreateCategoryDto dto);
}