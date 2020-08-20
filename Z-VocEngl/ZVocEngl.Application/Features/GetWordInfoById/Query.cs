using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ZVocEngl.DAL.Data.Models;

namespace ZVocEngl.Application.Features.GetWordInfoById
{
    public partial class GetWordInfoById
    {
        public class Query : IRequest<Word>
        {
            public int Id { get; set; }

            public Query(int id)
            {
                Id = id;
            }
        }
    }
}