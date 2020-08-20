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
using ZVocEngl.DAL.Repositories;
using ZVocEngl.DAL.Repositories.Interfaces;

namespace ZVocEngl.Application.Features.GetWordInfoById
{
    public partial class GetWordInfoById
    {
        public class Handler : IRequestHandler<GetWordInfoById.Query, Word>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Word> Handle(Query request, CancellationToken cancellationToken)
            {
                var helper = new WordHelper(_context);
                return await helper.GetWordByFilter(w => w.Id == request.Id);
            }
        }
    }
}