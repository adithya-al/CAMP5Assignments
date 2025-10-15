using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PatientsRegistration.Models;

namespace PatientsRegistration.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    //1-Get ConnectionString
    private readonly string connectionString;
    public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
    {
        _logger = logger;

        //2- Store Connectionstring from Configuaration
        connectionString = configuration.GetConnectionString("MVCConnectionString");
    }

    public IActionResult Index()
    {
        return View();
    }

    //https://localhost:7534/Home/Privacy
    public IActionResult Privacy()
    {
        // 4 - Calling Test Connection
        var isConnected = TestConnection();
        return View((object)isConnected.ToString());

        //Model =(object) isConnected.Tostring()
    }

    //3 - Test Connection Method
    private bool TestConnection()
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                return true;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
