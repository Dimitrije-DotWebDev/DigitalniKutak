using DigitalniKutak.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DigitalniKutak.Model.ENUMs;

namespace DigitalniKutak.Services
{
    public class SessionService
    {
        public string Token;
        public Korisnik Korisnik { get; set; } 

        public bool IsLoggedIn => !string.IsNullOrEmpty(Token);

        public bool IsNotLoggedIn => string.IsNullOrEmpty(Token);

        public bool canView =>  Korisnik.TipKorisnika <= UserType.professor;
        public bool cantView => Korisnik.TipKorisnika > UserType.professor;

    }
}
