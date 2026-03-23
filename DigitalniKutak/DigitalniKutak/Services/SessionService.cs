using DigitalniKutak.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalniKutak.Services
{
    public class SessionService
    {
        public string Token;
        public Korisnik Korisnik { get; set; } 

        public bool IsLoggedIn => !string.IsNullOrEmpty(Token);

    }
}
