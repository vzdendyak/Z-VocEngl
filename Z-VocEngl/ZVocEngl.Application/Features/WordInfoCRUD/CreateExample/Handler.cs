using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ZVocEngl.DAL.Data;

namespace ZVocEngl.Application.Features.WordInfoCRUD.CreateExample
{
    public partial class CreateExample
    {
        public class Handler : IRequestHandler<CreateExample.Command, int>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                await _context.Examples.AddAsync(request.Example);
                await _context.SaveChangesAsync();
                var example = await _context.Examples.OrderByDescending(w => w.Id).FirstOrDefaultAsync();
                return example.Id;
            }
        }
    }
}