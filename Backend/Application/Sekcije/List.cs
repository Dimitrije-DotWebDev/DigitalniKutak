using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Sekcije
{
    public class List
    {
        public class Query : IRequest<List<Sekcija>> { }

        public class Handler : IRequestHandler<Query, List<Sekcija>>
        {
        private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<List<Sekcija>> Handle(Query request, CancellationToken cancellationToken)
            {
                var sekcije = await _context.Sekcije.ToListAsync();
                return sekcije;
            }
        }
    }
}