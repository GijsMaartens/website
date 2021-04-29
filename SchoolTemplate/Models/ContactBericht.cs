using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolTemplate.Models
{
    public class ContactBerichtModel
    {

        [Required(ErrorMessage = "Een emailadres is verplicht.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Een naam is verplicht.")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Een geboortedatum is verplicht.")]
        public DateTime Geboortedatum { get; set; }

        [Required(ErrorMessage = "Een huisnummer is verplicht.")]
        public int Huisnummer { get; set; }

        [Required(ErrorMessage = "Een postcode is verplicht.")]
        public string Postcode { get; set; }

        [Required(ErrorMessage = "Een bericht is verplicht.")]
        public string Bericht { get; set; }
    }
}
