namespace DataAccessLibrary.Models;

public class DeviceDto
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Type { get; set; }
    public int BuildingId { get; set; }
    public int UserId { get; set; }
}