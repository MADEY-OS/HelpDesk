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
        CreateMap<Request, DetailedRequestDto>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User.Login))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.Device, opt => opt.MapFrom(src => src.Device.Brand + " " + src.Device.Model));
        CreateMap<User, DetailedUserDto>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name))
            .ForMember(dest => dest.Building, opt => opt.MapFrom(src => src.Building.Name));
        CreateMap<Device, DetailedDeviceDto>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User.Login))
            .ForMember(dest => dest.Building, opt => opt.MapFrom(src => src.Building.Name));
    }
}