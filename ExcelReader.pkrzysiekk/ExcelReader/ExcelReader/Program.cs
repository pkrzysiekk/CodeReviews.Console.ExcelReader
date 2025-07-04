using ExcelReader;
using ExcelReader.Controllers;
using ExcelReader.Data;

var context = new ExcelContext();
var excelFileReader = new ExcelFileReader();
var controller = new AppController(context, excelFileReader);
controller.Run();
controller.ShowCoffees();