using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ZVocEngl.DAL.Data;
using ZVocEngl.DAL.Data.Models;

namespace ZVocEngl.Application.Features.DeleteWordFromVocabulary
{
    public class DeleteWordFromVocabulary
    {
        public class Command : IRequest<bool>
        {
            public Command(int wordId, int vocabularyId)
            {
                WordId = wordId;
                VocabularyId = vocabularyId;
            }

            public int WordId { get; set; }
            public int VocabularyId { get; set; }
        }

        public class Handler : IRequestHandler<DeleteWordFromVocabulary.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    var item = await _context.VocabulariesWords.Where(words => 
                        words.VocabularyId==request.VocabularyId &&
                        words.WordId==request.WordId).FirstOrDefaultAsync();
                    _context.VocabulariesWords.Remove(item);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }
    }
}