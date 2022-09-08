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
    public class RoleService : IRoleService
    {
        private readonly HelpDeskDbContext _dbContext;
        private readonly IMapper _mapper;

        public RoleService(HelpDeskDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public RoleDto GetById(int id)
        {
            var role = _dbContext.Roles.FirstOrDefault(r => r.Id == id);

            if (role is null) return null;

            var result = _mapper.Map<RoleDto>(role);

            return result;
        }

        public IEnumerable<RoleDto> GetAll()
        {
            var roles = _dbContext.Roles.ToList();

            var rolesDtos = _mapper.Map<List<RoleDto>>(roles);

            return rolesDtos;
        }

        public int Create(CreateRoleDto dto)
        {
            var role = _mapper.Map<Role>(dto);

            _dbContext.Roles.Add(role);
            _dbContext.SaveChanges();

            return role.Id;
        }

        public bool Delete(int id)
        {
            var role = _dbContext.Roles.FirstOrDefault(r => r.Id == id);

            if (role is null) return false;

            _dbContext.Roles.Remove(role);
            _dbContext.SaveChanges();

            return true;
        }

        public bool Update(int id, CreateRoleDto dto)
        {
            var role = _dbContext.Roles.FirstOrDefault(r => r.Id == id);

            if (role is null) return false;
            
            role.Name = dto.Name;

            role.Description = dto.Description;

            _dbContext.SaveChanges();

            return true;
        }

    }
}
