using MediatR;
using ZVocEngl.DAL.Data.Models;

namespace ZVocEngl.Application.Features.WordInfoCRUD.CreateExample
{
    public partial class CreateExample
    {
        public class Command : IRequest<int>
        {
            public Example Example { get; set; }

            public Command(Example example)
            {
                Example = example;
            }
        }
    }
}