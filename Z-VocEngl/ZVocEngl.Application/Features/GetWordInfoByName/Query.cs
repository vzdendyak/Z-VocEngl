using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ZVocEngl.DAL.Data.Models;

namespace ZVocEngl.Application.Features.GetWordInfoByName
{
    public partial class GetWordInfoByName
    {
        public class Query : IRequest<Word>
        {
            public string Name { get; set; }

            public Query(string name)
            {
                Name = name;
            }
        }
    }
}