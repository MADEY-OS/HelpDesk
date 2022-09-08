namespace DataAccessLibrary.Entities;

public class Category //Kategorie requestów.
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Request> Requests { get; set; }
}