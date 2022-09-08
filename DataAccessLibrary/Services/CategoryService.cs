using AutoMapper;
using DataAccessLibrary.Data;
using DataAccessLibrary.Entities;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Services;

public class CategoryService : ICategoryService
{
    private readonly HelpDeskDbContext _dbContext;
    private readonly IMapper _mapper;

    public CategoryService(HelpDeskDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public CategoryDto GetById(int id)
    {
        var category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);

        if (category is null) return null;

        var result = _mapper.Map<CategoryDto>(category);

        return result;
    }

    public IEnumerable<CategoryDto> GetAll()
    {
        var categories = _dbContext.Categories.ToList();

        var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);

        return categoriesDto;
    }

    public int Create(CreateCategoryDto dto)
    {
        var category = _mapper.Map<Category>(dto);

        _dbContext.Categories.Add(category);
        _dbContext.SaveChanges();

        return category.Id;
    }

    public bool Delete(int id)
    {
        var category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);

        if (category is null) return false;

        _dbContext.Categories.Remove(category);
        _dbContext.SaveChanges();

        return true;
    }

    public bool Update(int id, CreateCategoryDto dto)
    {
        var category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);

        if (category is null) return false;
            
        category.Name = dto.Name;

        category.Description = dto.Description;

        _dbContext.SaveChanges();

        return true;
    }
}