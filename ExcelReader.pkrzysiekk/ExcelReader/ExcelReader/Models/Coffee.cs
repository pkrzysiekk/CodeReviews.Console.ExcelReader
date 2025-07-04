using System.Text;

namespace ExcelReader.Models;

public class Coffee
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Origin { get; set; }
    public required string RoastLevel { get; set; }
    public decimal Price { get; set; }
    public required string FlavorNotes { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("***************************************");
        sb.AppendLine($"Coffee Name: {Name}");
        sb.AppendLine($"Coffee Origin: {Origin}");
        sb.AppendLine($"Roast Level: {RoastLevel}");
        sb.AppendLine($"Coffee Price: {Price}");
        sb.AppendLine($"Coffee FlavorNotes: {FlavorNotes}");
        sb.AppendLine("****************************************");
        return sb.ToString();
    }
}