using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Korisnici
{
    public class KorisnikDTO
    {
        public string Token {get; set; }
        public string ImageUrl { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public UserType TipKorisnika { get; set; }
        public string Odeljenje { get; set; }
        public string Razred { get; set; }
        public DateTime DatumRodjenja { get; set; }
    }
}