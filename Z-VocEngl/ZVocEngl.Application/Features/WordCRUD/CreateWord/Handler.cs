using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ZVocEngl.Application.Features.Helpers;
using ZVocEngl.DAL.Data;
using ZVocEngl.DAL.Data.Models;

namespace ZVocEngl.Application.Features.WordCRUD.CreateWord
{
    public partial class CreateWord
    {
        public class Handler : IRequestHandler<CreateWord.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var helper = new WordHelper(_context);
                var exist = await helper.IsWordExist(request.Word.Name);
                if (exist)
                {
                    throw new Exception("Word with the same name is already exist");
                }

                await _context.Words.AddAsync(request.Word);
                await _context.SaveChangesAsync();
                var word = await _context.Words.Where(w => w.Name == request.Word.Name).FirstOrDefaultAsync();

                var vocabularyWord = new VocabulariesWords() {Id = 0, VocabularyId = 3, WordId = word.Id};
                await _context.VocabulariesWords.AddAsync(vocabularyWord);
                await _context.SaveChangesAsync();
                
                
                return true;
            }
        }
    }
}