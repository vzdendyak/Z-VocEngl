using MediatR;
using ZVocEngl.DAL.Data.Models;

namespace ZVocEngl.Application.Features.WordInfoCRUD.CreateCollocation
{
    public partial class CreateCollocation
    {
        public class Command : IRequest<int>
        {
            public CollocationWord CollocationWord { get; set; }

            public Command(CollocationWord collocationWord)
            {
                CollocationWord = collocationWord;
            }
        }
    }
}