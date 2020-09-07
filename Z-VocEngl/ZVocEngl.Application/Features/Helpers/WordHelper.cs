using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZVocEngl.DAL.Data;
using ZVocEngl.DAL.Data.Models;

namespace ZVocEngl.Application.Features.Helpers
{
    public class WordHelper
    {
        public AppDbContext _context { get; set; }

        public WordHelper(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Word> GetWordByFilter(Expression<Func<Word, bool>> filterPredicate)
        {
            return await _context.Words.Where(filterPredicate).Select(w => new Word
            {
                Id = w.Id,
                Name = w.Name,
                WordInformations = w.WordInformations.Select(wf => new WordInformation
                {
                    Id = wf.Id,
                    PartOfSpeech = new PartsOfSpeech
                    {
                        Id = wf.PartOfSpeech.Id,
                        Name = wf.PartOfSpeech.Name
                    },
                    Examples = wf.Examples.Select(e => new Example
                    {
                        Id = e.Id,
                        Text = e.Text,
                        WordInformationId = e.WordInformationId
                    }).ToList(),
                    Text = wf.Text,
                    Type = new DAL.Data.Models.Type
                    {
                        Id = wf.Type.Id,
                        Name = wf.Type.Name
                    },
                    WordId = wf.WordId,
                    TypeId = wf.TypeId,
                    PartOfSpeechId = wf.PartOfSpeechId,
                    CollocationWords = wf.CollocationWords.Select(cw => new CollocationWord
                    {
                        Id = cw.Id,
                        Text = cw.Text,
                        WordInformationId = cw.WordInformationId
                    }).ToList(),
                    DefinitionSynonyms = wf.DefinitionSynonyms.Select(ds => new DefinitionSynonym
                    {
                        Id = ds.Id,
                        Text = ds.Text,
                        WordInformationId = ds.WordInformationId
                    }).ToList()
                }).ToList()
            }).FirstOrDefaultAsync();
        }

        public async Task<bool> IsWordExist(string name)
        {
            var word = await _context.Words.Where(w => w.Name == name).FirstOrDefaultAsync();
            return word != null;
        }
    }
}