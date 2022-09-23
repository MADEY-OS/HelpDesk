using AutoMapper;
using DataAccessLibrary.Data;
using DataAccessLibrary.Entities;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Services;

public class RequestService : IRequestService
{
    private readonly HelpDeskDbContext _dbContext;
    private readonly IMapper _mapper;

    public RequestService(HelpDeskDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public IEnumerable<RequestDto> GetAll()
    {
        var requests = _dbContext.Requests.ToList();
        var requestsDtos = _mapper.Map<List<RequestDto>>(requests);

        return requestsDtos;
    }

    public RequestDto GetById(int id)
    {
        var request = _dbContext.Requests.FirstOrDefault(r => r.Id == id);

        if (request is null) return null;

        var result = _mapper.Map<RequestDto>(request);

        return result;
    }

    public int Create(CreateRequestDto dto)
    {
        var request = _mapper.Map<Request>(dto);

        _dbContext.Requests.Add(request);
        _dbContext.SaveChanges();

        return request.Id;
    }

    public bool Delete(int id)
    {
        var request = _dbContext.Requests.FirstOrDefault(r => r.Id == id);

        if (request is null) return false;

        _dbContext.Requests.Remove(request);
        _dbContext.SaveChanges();

        return true;
    }

    public bool Update(int id, CreateRequestDto dto)
    {
        var request = _dbContext.Requests.FirstOrDefault(r => r.Id == id);

        if (request is null) return false;

        request.Title = dto.Title;
        request.Description = dto.Description;
        request.Status = dto.Status;
        request.UserId = dto.UserId;
        request.CategoryId = dto.CategoryId;
        request.DeviceId = dto.DeviceId;
        request.FixerId = dto.FixerId;
        request.FixerOpinion = dto.FixerOpinion;

        _dbContext.SaveChanges();

        return true;
    }
}