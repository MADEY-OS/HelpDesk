namespace DataAccessLibrary.Entities;

public class Building
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual List<Device> Devices { get; set; }
    public virtual List<User> Users { get; set; }
}