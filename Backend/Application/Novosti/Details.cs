using Domain;
using MediatR;
using Persistence;

namespace Application.Novosti
{
    public class Details
    {
        public class Query : IRequest<Novost>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Novost>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<Novost> Handle(Query request, CancellationToken cancellationToken)
            {
                var novost = await _context.Novosti.FindAsync(request.Id);
                if(novost == null)
                {
                    throw new Exception("Novost nije pronađena");
                }
                return novost;
            }
        }
    }
}