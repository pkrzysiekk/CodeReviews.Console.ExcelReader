using OfficeOpenXml;

namespace ExcelReader;

public interface IExcelFileReader<T>
{
    public IEnumerable<T> Read(int pageIndex = 0);
    public ExcelWorksheet LoadWorksheet(int pageIndex= 0); 
    
}