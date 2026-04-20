using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Takmicenja
{
    public class List
    {
        public class Query : IRequest<List<Takmicenje>> { }

        public class Handler : IRequestHandler<Query, List<Takmicenje>>
        {
        private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<List<Takmicenje>> Handle(Query request, CancellationToken cancellationToken)
            {
                var takmicenja = await _context.Takmicenja
                                                .Include(t => t.PrijavljeneEkipe)
                                                .Include(t => t.Kreator)
                                                .ToListAsync();
                                                
                return takmicenja;
            }
        }
    }
}