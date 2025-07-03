using OfficeOpenXml;

namespace ExcelReader;

public interface IExcelFileReader<T>
{
    public IEnumerable<T> Read(int pageIndex);
    public ExcelWorksheet LoadWorksheet(int pageIndex); 
    
}