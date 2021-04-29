using System;

namespace SchoolTemplate.Database
{
  public class Evenement
  {
    public int Id { get; set; }
    
    public string Naam { get; set; }

    public string Beschrijving { get; set; }

    public string Locatie { get; set; }

    public string Logo { get; set; }

    public Decimal Prijs { get; set; }

    public DateTime Datum { get; set; }
  }
}
