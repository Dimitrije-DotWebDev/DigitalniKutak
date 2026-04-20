using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Takmicenja
{
    public class Details
    {
        public class Query : IRequest<Takmicenje>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Takmicenje>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<Takmicenje> Handle(Query request, CancellationToken cancellationToken)
            {
                var takmicenje = await _context.Takmicenja
                                                .Include(t => t.PrijavljeneEkipe)
                                                .Include(t => t.Kreator)
                                                .SingleOrDefaultAsync(t => t.Id == request.Id);
                if(takmicenje == null)
                {
                    throw new Exception("Takmicenje nije pronađena");
                }
                return takmicenje;
            }
        }
    }
}