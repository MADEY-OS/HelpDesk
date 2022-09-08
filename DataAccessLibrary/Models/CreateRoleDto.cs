using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Entities;

namespace DataAccessLibrary.Models
{
    public class CreateRoleDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
