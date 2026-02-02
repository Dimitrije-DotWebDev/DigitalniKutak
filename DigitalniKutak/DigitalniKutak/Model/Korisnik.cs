using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DigitalniKutak.Model.ENUMs;

namespace DigitalniKutak.Model
{
    public class Korisnik
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public UserType TipKorisnika { get; set; }
        public string Razred { get; set; }
        public string Odeljenje { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DatumRodjenja { get; set; }
    }
}
