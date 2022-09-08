using AutoMapper;
using DataAccessLibrary.Entities;
using DataAccessLibrary.Models;

namespace HelpDesk.API.Profiles;

public class HelpDeskMappingProfile : Profile
{
    public HelpDeskMappingProfile()
    {
        CreateMap<Building, BuildingDto>();
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<CreateDeviceDto, Device>();
        CreateMap<CreateBuildingDto, Building>();
        CreateMap<CreateUserDto, User>();
        CreateMap<CreateRoleDto, Role>();
        CreateMap<CreateRequestDto, Request>();
        CreateMap<Device, DeviceDto>();
        CreateMap<Request, RequestDto>();
        CreateMap<Role, RoleDto>();
        CreateMap<User, UserDto>();
    }
}