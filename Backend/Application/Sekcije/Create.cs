using Domain;
using MediatR;
using Persistence;

namespace Application.Sekcije
{
    public class Create
    {
        public class Command : IRequest
        {
            public string Naziv { get; set; } = null!;
            public string Opis { get; set; } = null!;
            public DateTime TerminOdrzavanja { get; set; }
            public Guid ProfesorId { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var sekcija = new Sekcija
                {
                    Id = Guid.NewGuid(),
                    Naziv = request.Naziv,
                    Opis = request.Opis,
                    TerminOdrzavanja = request.TerminOdrzavanja,
                    ProfesorId = request.ProfesorId
                };

                _context.Sekcije.Add(sekcija);
                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;

                throw new Exception("Problem pri kreiranju sekcije");
            }
        }
    }
}