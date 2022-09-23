using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Entities;

public class Request
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }

    [Column(TypeName="date")]
    public DateTime Date { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public int DeviceId { get; set; }
    public virtual Device Device { get; set; }
    public int FixerId { get; set; }
    public string FixerOpinion { get; set; }
}