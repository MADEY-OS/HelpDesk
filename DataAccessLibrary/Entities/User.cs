namespace DataAccessLibrary.Entities;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string sName { get; set; }
    public string Phone { get; set; }
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }
    public int BuildingId { get; set; }
    public virtual Building Building { get; set; }
    public virtual List<Request> Requests { get; set; }
    public virtual List<Device> Devices { get; set; }
}