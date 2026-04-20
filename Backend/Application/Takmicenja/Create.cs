using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Takmicenja
{
    public class Create
    {
        public class Command : IRequest
        {
            public string Naziv { get; set; } = null!;
            public string Opis { get; set; } = null!;
            public DateTime DatumOdrzavanja { get; set; }
            public bool PoOdeljenju { get; set; }
            public CompeitionCategory Kategorija { get; set; }
            public bool DozvoliNaziveEkipa { get; set; }
            public int MaxBrojClanova { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor userAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                this._context = context;
                this.userAccessor = userAccessor;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var takmicenje = new Takmicenje
                {
                    Id = Guid.NewGuid(),
                    Naziv = request.Naziv,
                    Opis = request.Opis,
                    DatumOdrzavanja = request.DatumOdrzavanja,
                    PoOdeljenju = request.PoOdeljenju,
                    Kategorija = request.Kategorija,
                    DozvoliNaziveEkipa = request.DozvoliNaziveEkipa,
                    MaxBrojClanova = request.MaxBrojClanova
                };

                var korisnik = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userAccessor.GetCurrentUsername());
                takmicenje.KreatorId = korisnik.Id;

                _context.Takmicenja.Add(takmicenje);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}