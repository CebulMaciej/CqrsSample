using System;
using System.Threading.Tasks;
using CqrsSample.Api.Models;
using CqrsSample.Application.Command;
using CqrsSample.Application.Dtos;
using CqrsSample.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsSample.Api.Controllers
{
    [ApiController]
    [Route("examples")]
    public class ExampleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExampleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            ExampleDto p = await _mediator.Send(new GetExample
            {
                Id = id
            });
            if (p is null)
            {
                return NotFound();
            }

            return Ok(p);
        }

        [HttpPost]
        public async Task<ActionResult> Post(AddExampleRequestModel requestModel)
        {
            CreateExample createExample = new CreateExample(requestModel.Content);

            Guid p = await _mediator.Send(createExample);

            return Created($"/examples/{p}", null);
        }
    }
}