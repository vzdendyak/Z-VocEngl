using MediatR;
using ZVocEngl.DAL.Data.Models;

namespace ZVocEngl.Application.Features.WordInfoCRUD.CreateSynonym
{
    public partial class CreateSynonym
    {
        public class Command : IRequest<int>
        {
            public DefinitionSynonym DefinitionSynonym { get; set; }

            public Command(DefinitionSynonym definitionSynonym)
            {
                DefinitionSynonym = definitionSynonym;
            }
        }
    }
}