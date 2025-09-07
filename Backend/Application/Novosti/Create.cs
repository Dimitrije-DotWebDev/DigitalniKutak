using Domain;
using MediatR;
using Persistence;
using Microsoft.AspNetCore.Http;

namespace Application.Novosti
{
    public class Create
    {
        public class Command : IRequest
        {
            public string Naslov { get; set; } = null!;
            public string Sadrzaj { get; set; } = null!;
            /*public IFormFile Slika { get; set; } = null!;
            public IFormFile Fajl { get; set; } = null!;*/
            public int GrupaId { get; set; }
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
                var novost = new Novost
                {
                    Id = Guid.NewGuid(),
                    Naslov = request.Naslov,
                    Sadrzaj = request.Sadrzaj,
                    Timestamp = DateTime.Now,
                    GrupaId = request.GrupaId
                };

                _context.Novosti.Add(novost);
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}