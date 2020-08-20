using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZVocEngl.Application.Features.AddWordToVocabulary;
using ZVocEngl.DAL.Data.DTOs;

namespace ZVocEngl.API.Controllers
{
    [Route("api/vocabulary")]
    [ApiController]
    public class VocabularyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VocabularyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVocabularyInfo(int id)
        {
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> AddWord([FromBody] VocabularyWordRelationDto relationDto)
        {
            var command = new AddWordToVocabulary.Command()
                {VocabularyId = relationDto.VocabularyId, WordId = relationDto.WordId};
            var res = await _mediator.Send(command);
            if (res)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}