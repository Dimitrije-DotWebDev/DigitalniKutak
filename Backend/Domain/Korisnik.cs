using Microsoft.AspNetCore.Identity;
namespace Domain
{
    public class Korisnik : IdentityUser
    {
        public string Ime {get; set;}
        public string Prezime {get; set;}
        public UserType TipKorisnika { get; set; }
        public string Razred {get; set; }
        public string Odeljenje {get; set; }
        public string ImageUrl { get; set; }
        public DateTime DatumRodjenja { get; set; }
    }
}