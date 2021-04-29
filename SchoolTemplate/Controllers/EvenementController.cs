using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SchoolTemplate.Database;
using SchoolTemplate.Models;

namespace SchoolTemplate.Controllers
{
    public class EvenementController : Controller
    {
        string connectionString = "Server=informatica.st-maartenscollege.nl;Port=3306;Database=110086;Uid=110086;Pwd=veysches;";

        [Route("evenementen")]
        public IActionResult Evenementen()
        {
            return View(GetEvenementen());
        }

        [Route("evenementen/{id}")]
        public IActionResult Evenement(string id)
        {
            return View(GetEvenement(id));
        }

        private Evenement GetEvenement(string id)
        {
            List<Evenement> evenementen = new List<Evenement>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM evenementen WHERE id = " + id + ";", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Evenement evenement = BuildEvenement(reader);
                        evenementen.Add(evenement);
                    }
                }
            }
            return evenementen[0];
        }

        private List<Evenement> GetEvenementen()
        {
            List<Evenement> evenementen = new List<Evenement>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM evenementen", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Evenement evenement = BuildEvenement(reader);
                        evenementen.Add(evenement);
                    }
                }
            }
            return evenementen;
        }

        private Evenement BuildEvenement(MySqlDataReader reader)
        {
            return new Evenement
            {
                Id = Convert.ToInt32(reader["id"]),
                Naam = reader["naam"].ToString(),
                Beschrijving = reader["beschrijving"].ToString(),
                Locatie = reader["locatie"].ToString(),
                Logo = reader["logo"].ToString(),
                Prijs = Decimal.Parse(reader["prijs"].ToString()),
                Datum = DateTime.Parse(reader["datum"].ToString()),
            };
        }
    }
}
