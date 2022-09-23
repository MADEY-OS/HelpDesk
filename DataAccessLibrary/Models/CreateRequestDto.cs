using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class CreateRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int DeviceId { get; set; }
        public int FixerId { get; set; }
        public string FixerOpinion { get; set; }
    }
}
