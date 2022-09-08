using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<RoleDto> GetAll();
        RoleDto GetById(int id);
        int Create(CreateRoleDto id);
        bool Delete(int id);
        bool Update(int id, CreateRoleDto dto);

    }
}
