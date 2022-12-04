using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using System.Diagnostics;
using TP3.Models;
//using System.Data.SQLite;
namespace TP3.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            Debug.WriteLine("Hello World !!! .... ");
            SQLiteConnection dbCon = new SQLiteConnection("Data Source=C:\\Users\\Louay\\Desktop\\2022 GL3 .NET Framework TP3 - SQLite database.db;");
            dbCon.Open();

            using (dbCon)
            {
                SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM personal_info", dbCon);
                SQLiteDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        string first_name = (string)reader["first_name"];
                        string last_name = (string)reader["last_name"];
                        string email = (string)reader["email"];
                        //   DateTime date_birth = Convert.ToDateTime((string)reader["date_birth"].ToString());
                        string image = (string)reader["image"];
                        string country = (string)reader["country"];

                        Debug.WriteLine("id = {0} first name = {1}  last name = {2}  email={3}  image= {4}  country= {5}  date=", id, first_name, last_name, email, image, country);
                    }


                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}