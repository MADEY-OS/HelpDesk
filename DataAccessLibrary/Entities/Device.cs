namespace DataAccessLibrary.Entities;

public class Device //Urządzenia
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Type { get; set; }
    public int BuildingId { get; set; }
    public virtual Building Building { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public virtual List<Request> Requests { get; set; }
}