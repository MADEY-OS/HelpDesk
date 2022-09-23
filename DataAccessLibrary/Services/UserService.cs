using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLibrary.Data;
using DataAccessLibrary.Entities;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Services
{
    public class UserService : IUserService
    {
        private readonly HelpDeskDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(HelpDeskDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public UserDto GetById(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);

            if (user is null) return null;

            var result = _mapper.Map<UserDto>(user);

            return result;
        }

        public IEnumerable<UserDto> GetAll()
        {
            var users = _dbContext.Users.ToList();

            var usersDto = _mapper.Map<List<UserDto>>(users);

            return usersDto;
        }

        public int Create(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }

        public bool Delete(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);

            if (user is null) return false;

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();

            return true;
        }

        public bool Update(int id, CreateUserDto dto)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);

            if (user is null) return false;

            user.Login = dto.Login;
            user.Password = dto.Password;
            user.Email = dto.Email;
            user.Name = dto.Name;
            user.sName = dto.sName;
            user.Phone = dto.Phone;
            user.RoleId = dto.RoleId;
            user.BuildingId = dto.BuildingId;

            _dbContext.SaveChanges();

            return true;
        }
    }
}
