namespace ExcelReader.Models;

public class Coffee
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Origin { get; set; }
    public required string RoastLevel { get; set; }
    public decimal Price { get; set; }
    public required string FlavorNotes { get; set; }
}