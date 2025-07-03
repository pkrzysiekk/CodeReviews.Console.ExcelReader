using OfficeOpenXml;

namespace ExcelReader;

public interface IExcelFileReader<T>
{
    public IEnumerable<T> Read();
    public ExcelWorksheet LoadWorksheet(); 
    
}