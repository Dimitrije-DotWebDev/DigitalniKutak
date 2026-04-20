using Domain;
using MediatR;
using Persistence;

namespace Application.Sekcije
{
    public class Details
    {
        public class Query : IRequest<Sekcija>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Sekcija>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<Sekcija> Handle(Query request, CancellationToken cancellationToken)
            {
                var sekcija = await _context.Sekcije.FindAsync(request.Id);
                if(sekcija == null)
                {
                    throw new Exception("Sekcija nije pronađena");
                }
                return sekcija;
            }
        }
    }
}