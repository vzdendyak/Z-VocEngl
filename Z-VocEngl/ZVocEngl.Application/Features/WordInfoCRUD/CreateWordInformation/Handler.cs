using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ZVocEngl.DAL.Data;

namespace ZVocEngl.Application.Features.WordInfoCRUD.CreateWordInformation
{
    public partial class CreateWordInformation
    {
        public class Handler : IRequestHandler<CreateWordInformation.Command, int>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateWordInformation.Command request, CancellationToken cancellationToken)
            {
                await _context.WordInformations.AddAsync(request.WordInformation);
                await _context.SaveChangesAsync();
                var wInfo = await _context.WordInformations.OrderByDescending(w=>w.Id).FirstOrDefaultAsync();
                return wInfo.Id;
            }
        }
    }
}