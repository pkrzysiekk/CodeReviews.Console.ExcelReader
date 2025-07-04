using EFCore.BulkExtensions;
using ExcelReader.Data;
using ExcelReader.Models;

namespace ExcelReader.Controllers;

public class AppController
{
    private readonly ExcelContext _context;
    private readonly IExcelFileReader<Coffee> _fileReader;

    public AppController(ExcelContext context, IExcelFileReader<Coffee> fileReader)
    {
        _context = context;
        _fileReader = fileReader;
    }

    public void Run()
    {
        _context.Initialize();
        var coffees = _fileReader.Read();
        _context.BulkInsert(coffees);
        _context.SaveChanges();
    }
}