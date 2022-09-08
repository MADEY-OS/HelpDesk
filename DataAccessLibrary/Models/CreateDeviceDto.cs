using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class CreateDeviceDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int BuildingId { get; set; }
        public int UserId { get; set; }
    }
}
