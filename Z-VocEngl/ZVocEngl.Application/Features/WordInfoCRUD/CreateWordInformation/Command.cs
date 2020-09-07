using MediatR;
using ZVocEngl.DAL.Data.Models;

namespace ZVocEngl.Application.Features.WordInfoCRUD.CreateWordInformation
{
    public partial class CreateWordInformation
    {
        public class Command : IRequest<int>
        {
            public WordInformation WordInformation { get; set; }

            public Command(WordInformation wordInformation)
            {
                WordInformation = wordInformation;
            }
        }
    }
}