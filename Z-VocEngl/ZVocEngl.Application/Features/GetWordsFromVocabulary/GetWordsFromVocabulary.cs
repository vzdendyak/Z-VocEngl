using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ZVocEngl.Application.Features.Helpers;
using ZVocEngl.DAL.Data;
using ZVocEngl.DAL.Data.Models;

namespace ZVocEngl.Application.Features.GetWordsFromVocabulary
{
    public class GetWordsFromVocabulary
    {
        public class Query : IRequest<IEnumerable<Word>>
        {
            public int Id { get; set; }

            public Query(int id)
            {
                Id = id;
            }
        }

        public class Handler : IRequestHandler<GetWordsFromVocabulary.Query, IEnumerable<Word>>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Word>> Handle(Query request, CancellationToken cancellationToken)
            {
                var words = await _context.VocabulariesWords
                    .Where(w => w.VocabularyId == request.Id)
                    .Include(w => w.Word)
                    .Select(w => new Word
                    {
                        Id = w.Word.Id,
                        Name = w.Word.Name
                    }).ToListAsync();
                return words;
            }
        }
    }
}