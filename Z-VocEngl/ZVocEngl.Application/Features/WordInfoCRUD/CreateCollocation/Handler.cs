using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ZVocEngl.DAL.Data;
using ZVocEngl.DAL.Data.Models;

namespace ZVocEngl.Application.Features.WordInfoCRUD.CreateCollocation
{
    public partial class CreateCollocation
    {
        public class Handler : IRequestHandler<CreateCollocation.Command, int>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                await _context.CollocationWords.AddAsync(request.CollocationWord);
                await _context.SaveChangesAsync();
                var cw = await _context.CollocationWords.OrderByDescending(w => w.Id).FirstOrDefaultAsync();
                return cw.Id;
            }
        }
    }
}