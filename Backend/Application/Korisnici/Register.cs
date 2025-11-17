using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistence;
using Microsoft.AspNetCore.Http;
using Backend.Application.Common.Services;
using Microsoft.EntityFrameworkCore;


namespace Application.Korisnici
{
    public class Register
    {
        public class Command : IRequest<KorisnikDTO>
        {
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public UserType TipKorisnika { get; set; }
            public string Odeljenje { get; set; }
            public string Razred { get; set; }
            public DateTime DatumRodjenja { get; set; }
            public IFormFile Slika { get; set; }
        }

        public class Handler : IRequestHandler<Command, KorisnikDTO>
        {
            private readonly UserManager<Korisnik> _userManager;
            private readonly UploadFileService _uploadFileService;
            private readonly DataContext _context;

            public Handler(DataContext context, UserManager<Korisnik> userManager, UploadFileService uploadFileService)
            {
                _userManager = userManager;
                _uploadFileService = uploadFileService;
                _context = context;
            }

            public async Task<KorisnikDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await _context.Users.Where(x => x.Email == request.Email).AnyAsync())
                {
                    throw new Exception("Korisnik sa unetom email adresom već postoji");
                }
                if(await _context.Users.Where(x => x.UserName == request.UserName).AnyAsync())
                {
                    throw new Exception("Korisnik sa unetim korisničkim imenom već postoji");
                }

                var korisnik = new Korisnik
                {
                    Ime =  request.Ime,
                    Prezime = request.Prezime,
                    Email = request.Email,
                    UserName = request.UserName,
                    TipKorisnika = request.TipKorisnika,
                    Odeljenje = request.Odeljenje,
                    Razred = request.Razred,
                    DatumRodjenja = request.DatumRodjenja,
                    ImageUrl = ""
                };

                if (request.Slika != null)
                {
                    var deoPutanje = Path.Combine(Directory.GetCurrentDirectory(), @$"Uploads\Korisnici\{korisnik.Id}-{korisnik.UserName}");
                    var slikaPutanja = _uploadFileService.UploadFile(request.Slika, FileType.Image, deoPutanje);
                    korisnik.ImageUrl = slikaPutanja.Replace("\\", "/").Split("API/").Last();
                }

                var result = await _userManager.CreateAsync(korisnik, request.Password);

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

                throw new Exception("Problem pri registraciji korisnika");
            }
        }
    }
}