using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiMediatR.Commands;

namespace WebApiMediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeoplesController : ControllerBase
    {
        public IMediator Mediator { get; }

        public PeoplesController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<PeopleResult>> Get()
        {
            return await Mediator.Send(new PeopleGetCommand());
        }

        [HttpGet("{id}")]
        public async Task<PeopleResult> Get(int id)
        {
            return await Mediator.Send(new PeopleGetByIdCommand(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PeopleCreateCommand value)
        {
            if (ModelState.IsValid)
            {
                var result = await Mediator.Send(value);
                return Ok(result);
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PeopleUpdateCommand value)
        {
            if (id != value.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var result = await Mediator.Send(value);
                return Ok(result);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new PeopleRemoveByIdCommand(id));
            if (result)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
