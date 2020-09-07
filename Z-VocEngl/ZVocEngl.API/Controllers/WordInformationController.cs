using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZVocEngl.Application.Features.WordInfoCRUD.CreateCollocation;
using ZVocEngl.Application.Features.WordInfoCRUD.CreateExample;
using ZVocEngl.Application.Features.WordInfoCRUD.CreateSynonym;
using ZVocEngl.Application.Features.WordInfoCRUD.CreateWordInformation;
using ZVocEngl.Application.Features.WordInfoCRUD.DeleteOperations;
using ZVocEngl.DAL.Data.Models;

namespace ZVocEngl.API.Controllers
{
    [Route("api/words/information")]
    [ApiController]
    public class WordInformationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WordInformationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWordInformation([FromBody] WordInformation information)
        {
            var query = new CreateWordInformation.Command(information);
            var result = await _mediator.Send(query);
            return Ok(new
            {
                id = result
            });
        }

        [HttpPost("synonyms")]
        public async Task<IActionResult> CreateSynonym([FromBody] DefinitionSynonym synonym)
        {
            var query = new CreateSynonym.Command(synonym);
            var result = await _mediator.Send(query);
            return Ok(new
            {
                id = result
            });
        }

        [HttpPost("examples")]
        public async Task<IActionResult> CreateExample([FromBody] Example example)
        {
            var query = new CreateExample.Command(example);
            var result = await _mediator.Send(query);
            return Ok(new
            {
                id = result
            });
        }

        [HttpPost("collocations")]
        public async Task<IActionResult> CreateCollocation([FromBody] CollocationWord collocationWord)
        {
            var query = new CreateCollocation.Command(collocationWord);
            var result = await _mediator.Send(query);
            return Ok(new
            {
                id = result
            });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWordInformation(int id)
        {
            var query = new DeleteWordInformation.Command(id);
            var result = await _mediator.Send(query);
            return Ok(new
            {
                success = result
            });
        }

        [HttpDelete("examples/{id}")]
        public async Task<IActionResult> DeleteExample(int id)
        {
            var query = new DeleteExample.Command(id);
            var result = await _mediator.Send(query);
            return Ok(new
            {
                success = result
            });
        }

        [HttpDelete("collocations/{id}")]
        public async Task<IActionResult> DeleteCollocation(int id)
        {
            var query = new DeleteCollocation.Command(id);
            var result = await _mediator.Send(query);
            return Ok(new
            {
                success = result
            });
        }

        [HttpDelete("synonyms/{id}")]
        public async Task<IActionResult> DeleteSynonym(int id)
        {
            var query = new DeleteSynonym.Command(id);
            var result = await _mediator.Send(query);
            return Ok(new
            {
                success = result
            });
        }
    }
}