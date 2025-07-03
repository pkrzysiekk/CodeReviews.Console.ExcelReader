using ExcelReader;
using ExcelReader.Controllers;
using ExcelReader.Data;

var context= new ExcelContext();
var ExcelFileReader= new ExcelFileReader();
var controller= new AppController(context,ExcelFileReader);
controller.Run();