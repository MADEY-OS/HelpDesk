using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Employee.Models
{
    public class CreateRequestModel
    {
        [Required(ErrorMessage = "Pole opisu krótkiego, nie może byc puste!"), StringLength(30, ErrorMessage = "Skrócony opis problemu, jest za długi. (max 30 znaków).")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Pole opisu szczegółowego, nie może byc puste!"), StringLength(300, ErrorMessage = "Opis jest za długi, Postaraj zmieścić się w 300 znakach.")]
        public string Description { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int DeviceId { get; set; }
        public int FixerId { get; set; }
        public string FixerOpinion { get; set; }
    }
}
