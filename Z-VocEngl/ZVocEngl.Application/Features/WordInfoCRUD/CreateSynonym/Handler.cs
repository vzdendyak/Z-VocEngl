using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ZVocEngl.DAL.Data;

namespace ZVocEngl.Application.Features.WordInfoCRUD.CreateSynonym
{
    public partial class CreateSynonym
    {
        public class Handler : IRequestHandler<CreateSynonym.Command, int>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }


            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                await _context.DefinitionSynonyms.AddAsync(request.DefinitionSynonym);
                await _context.SaveChangesAsync();
                var synonym = await _context.DefinitionSynonyms.OrderByDescending(w => w.Id).FirstOrDefaultAsync();
                return synonym.Id;
            }
        }
    }
}