using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZVocEngl.Application.Features.Helpers;
using ZVocEngl.DAL.Data;
using ZVocEngl.DAL.Data.Models;

namespace ZVocEngl.Application.Features.GetWordInfoByName
{
    public partial class GetWordInfoByName
    {
        public class Handler : IRequestHandler<GetWordInfoByName.Query, Word>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Word> Handle(Query request, CancellationToken cancellationToken)
            {
                var helper = new WordHelper(_context);
                return await helper.GetWordByFilter(w => w.Name == request.Name);
            }
        }
    }
}