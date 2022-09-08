namespace DataAccessLibrary.Models;

public class RequestDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Date { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public int DeviceId { get; set; }
    public int FixerId { get; set; }
    public string FixerOpinion { get; set; }
}