using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Domain;
using Persistence;
using Microsoft.AspNetCore.Identity;

namespace Application.Korisnici
{
    public class Login
    {
        public class Query : IRequest<KorisnikDTO>
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class Handler : IRequestHandler<Query, KorisnikDTO>
        {
            private readonly UserManager<Korisnik> _userManager;
            private readonly SignInManager<Korisnik> _signInManager;

            public Handler(UserManager<Korisnik> userManager, SignInManager<Korisnik> signInManager)
            {
                _userManager = userManager;
                _signInManager = signInManager;
            }

            public async Task<KorisnikDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var korisnik = await _userManager.FindByEmailAsync(request.Email);

                if (korisnik == null)
                    throw new Exception("Ne postoji korisnik sa unetom email adresom");

                var result = await _signInManager.CheckPasswordSignInAsync(korisnik, request.Password, false);

                if (result.Succeeded)
                {
                    return new KorisnikDTO
                    {
                        Ime = korisnik.Ime,
                        Prezime = korisnik.Prezime,
                        Email = korisnik.Email,
                        TipKorisnika = korisnik.TipKorisnika,
                        ImageUrl = korisnik.ImageUrl,
                        Razred = korisnik.Razred,
                        Odeljenje = korisnik.Odeljenje,
                        Token = "MOCK_TOKEN"
                    };
                }

                throw new Exception("Pogrešna lozinka");
            }
        }
    }
}