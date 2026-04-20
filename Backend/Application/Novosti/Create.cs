using Domain;
using MediatR;
using Persistence;
using Microsoft.AspNetCore.Http;
using Backend.Application.Common.Services;

namespace Application.Novosti
{
    public class Create
    {
        public class Command : IRequest
        {
            public string Naslov { get; set; } = null!;
            public string Sadrzaj { get; set; } = null!;
            public IFormFile Slika { get; set; } = null!;
            public IFormFile Fajl { get; set; } = null!;
            public int GrupaId { get; set; }
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
                var novost = new Novost
                {
                    Id = Guid.NewGuid(),
                    Naslov = request.Naslov,
                    Sadrzaj = request.Sadrzaj,
                    Timestamp = DateTime.Now,
                    GrupaId = request.GrupaId,
                    SlikaPutanja = "",
                    FajlPutanja = ""
                };
                if (request.Slika != null)
                {
                    var deoPutanje = Path.Combine(Directory.GetCurrentDirectory(), @$"Uploads\Novosti\{novost.Timestamp.ToString("yyyy-MM-dd")}\{novost.Naslov}-{novost.Id}");
                    var slikaPutanja = _uploadFileService.UploadFile(request.Slika, FileType.Image, deoPutanje);
                    novost.SlikaPutanja = slikaPutanja.Replace("\\", "/").Split("API/").Last();
                }

                if (request.Fajl != null)
                {
                    var deoPutanje = Path.Combine(Directory.GetCurrentDirectory(), @$"Uploads\Novosti\{novost.Timestamp.ToString("yyyy-MM-dd")}\{novost.Naslov}-{novost.Id}"); 
                    var fajlPutanja = _uploadFileService.UploadFile(request.Fajl, FileType.Document, deoPutanje);
                    novost.FajlPutanja = fajlPutanja.Replace("\\", "/").Split("API/").Last();
                }

                _context.Novosti.Add(novost);
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}