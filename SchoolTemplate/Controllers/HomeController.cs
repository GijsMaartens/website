using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SchoolTemplate.Models;

namespace SchoolTemplate.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      string connectionString =
        "Server=145.103.105.227;Port=3306;Database=fastfood;Uid=lgg;Pwd=LifeUniverseEverything;SslMode=Required";
      
      using (MySqlConnection conn = new MySqlConnection(connectionString))
      {
        conn.Open();
        MySqlCommand cmd = new MySqlCommand("select * from products", conn);

        using (var reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {

            int Id = Convert.ToInt32(reader["Id"]);
            string Name = reader["Naam"].ToString();
          }
        }

      }

      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
