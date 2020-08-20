using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ZVocEngl.DAL.Data;
using ZVocEngl.DAL.Data.Models;

namespace ZVocEngl.Application.Features.AddWordToVocabulary
{
    public partial class AddWordToVocabulary
    {
        public class Handler : IRequestHandler<AddWordToVocabulary.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var relation = new VocabulariesWords {VocabularyId = request.VocabularyId, WordId = request.WordId};
                try
                {
                    _context.VocabulariesWords.Add(relation);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }
        }
    }
}