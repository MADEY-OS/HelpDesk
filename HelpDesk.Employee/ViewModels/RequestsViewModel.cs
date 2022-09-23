using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Employee.ViewModels
{
    public class RequestsViewModel
    { 
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        public string FixerOpinion { get; set; }
    }
}
