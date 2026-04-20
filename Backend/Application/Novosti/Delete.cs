using Domain;
using MediatR;
using Persistence;
using Microsoft.AspNetCore.Http;
using Backend.Application.Common.Services;
namespace Application.Novosti
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly UploadFileService _uploadFileService;
            public Handler(DataContext context, UploadFileService uploadFileService)
            {
                this._uploadFileService = uploadFileService;
                this._context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var novost = await _context.Novosti.FindAsync(request.Id);

                if (novost == null)
                    throw new Exception("Could not find news item");

                if (!string.IsNullOrEmpty(novost.SlikaPutanja))
                {
                    var slikaPutanja = Path.Combine(Directory.GetCurrentDirectory(), novost.SlikaPutanja);
                    _uploadFileService.DeleteFile(slikaPutanja);
                }

                if (!string.IsNullOrEmpty(novost.FajlPutanja))
                {
                    var fajlPutanja = Path.Combine(Directory.GetCurrentDirectory(), novost.FajlPutanja);
                    _uploadFileService.DeleteFile(fajlPutanja);
                }

                _context.Novosti.Remove(novost);
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}