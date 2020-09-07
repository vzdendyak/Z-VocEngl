using MediatR;
using ZVocEngl.DAL.Data.Models;

namespace ZVocEngl.Application.Features.WordCRUD.CreateWord
{
    public partial class CreateWord
    {
        public class Command : IRequest<bool>
        {
            public Word Word { get; set; }

            public Command(Word word)
            {
                Word = word;
            }
        }
    }
}