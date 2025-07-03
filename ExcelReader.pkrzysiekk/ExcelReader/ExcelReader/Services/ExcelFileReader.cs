using ExcelReader.Models;
using OfficeOpenXml;

namespace ExcelReader;

public class ExcelFileReader : IExcelFileReader<Coffee>
{
    private string _filePath;
    static ExcelFileReader()
    {
        ExcelPackage.License.SetNonCommercialPersonal("pkrzysiekk Pavel");
    }

    public ExcelFileReader()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Data", "data.xlsx");
        _filePath=Path.GetFullPath(path); 
    }
    public IEnumerable<Coffee> Read(int pageIndex=0)
    {
     using var worksheet = LoadWorksheet();

     int rowCount = worksheet.Rows.Count();
        List<Coffee> coffees = new List<Coffee>();
        for (int row = 2; row <= rowCount; row++)
        {
            var coffee = new Coffee()
            {
                Name = worksheet.Cells[row, 1].Value.ToString(),
                Origin = worksheet.Cells[row, 2].Value.ToString(),
                RoastLevel = worksheet.Cells[row, 3].Value.ToString(),
                Price =decimal.Parse(worksheet.Cells[row, 4].Value.ToString()),
                FlavorNotes = worksheet.Cells[row, 5].Value.ToString(),
            };
            coffees.Add(coffee);
        }
        return coffees;
        
    }

    public ExcelWorksheet LoadWorksheet(int pageIndex=0)
    { 
        var package = new ExcelPackage(_filePath);
        var worksheet = package.Workbook.Worksheets[pageIndex];
        if(worksheet==null) throw new Exception("ExcelFileReader: worksheet is null");
        return worksheet;
    }
}