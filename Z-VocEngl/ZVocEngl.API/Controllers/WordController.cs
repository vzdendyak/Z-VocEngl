using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZVocEngl.Application.Features.GetWordInfoByName;
using ZVocEngl.Application.Features.GetWordInfoById;
using ZVocEngl.DAL.Data.Models;
using ZVocEngl.DAL.Repositories.Interfaces;

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
    }
}