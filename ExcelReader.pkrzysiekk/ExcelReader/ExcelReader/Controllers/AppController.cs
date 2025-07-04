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
        Console.WriteLine("Creating a table for the data");
        _context.Initialize();
        Console.WriteLine("Reading the doc");
        var coffees = _fileReader.Read();
        Console.WriteLine("Inserting the data");
        _context.BulkInsert(coffees);
        _context.SaveChanges();
    }

    public void ShowCoffees()
    {
        Console.WriteLine("Click any key to get another coffee page or q to exit");
        var key = Console.ReadKey().ToString();
        var pageNumber = 1;
        var pageSize = 20;
        while (key != "q")
        {
            var pagedCoffees = GetPagedData(pageNumber, pageSize);
            if (!pagedCoffees.Any())
            {
                Console.WriteLine("No more Coffees found");
                return;
            }

            foreach (var coffee in pagedCoffees)
                Console.WriteLine(coffee.ToString());

            pageNumber++;
            Console.WriteLine("Click any key to get another coffee page or q to exit");
            key = Console.ReadKey().ToString();
        }
    }

    private IEnumerable<Coffee> GetPagedData(int pageNumber, int pageSize)
    {
        return _context.Coffees.Skip((pageNumber - 1) * pageSize).Take(pageSize);
    }
}