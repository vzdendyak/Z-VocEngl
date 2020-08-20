using MediatR;

namespace ZVocEngl.Application.Features.AddWordToVocabulary
{
    public partial class AddWordToVocabulary
    {
        public class Command : IRequest<bool>
        {
            public int WordId { get; set; }
            public int VocabularyId { get; set; }
        }
    }
  
}