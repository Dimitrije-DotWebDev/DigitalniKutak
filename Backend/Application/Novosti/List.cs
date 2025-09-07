using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Novosti
{
    public class List
    {
        public class Query : IRequest<List<Novost>> { }

        public class Handler : IRequestHandler<Query, List<Novost>>
        {
        private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<List<Novost>> Handle(Query request, CancellationToken cancellationToken)
            {
                var novosti = await _context.Novosti.ToListAsync();
                return novosti;
            }
        }
    }
}