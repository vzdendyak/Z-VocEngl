using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZVocEngl.Application.Features.GetWordInfoByName;
using ZVocEngl.Application.Features.GetWordInfoById;
using ZVocEngl.Application.Features.WordCRUD.CreateWord;
using ZVocEngl.DAL.Data.Models;

namespace ZVocEngl.API.Controllers
{
    [Route("api/words")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetWordInfoById.Query(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var query = new GetWordInfoByName.Query(name);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Word word)
        {
            var query = new CreateWord.Command(word);
            var result = await _mediator.Send(query);
            return result ? (IActionResult) Ok() : BadRequest();
        }

        
    }
}