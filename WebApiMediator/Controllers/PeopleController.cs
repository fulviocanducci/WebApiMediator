using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SimpleSoft.Mediator;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApiMediator.Commands.Create;
using WebApiMediator.Commands.Delete;
using WebApiMediator.Commands.Query;
using WebApiMediator.Commands.Update;
using WebApiMediator.Models;

//https://medium.com/swlh/mediator-pattern-in-asp-net-core-applications-109b4231c0f8
namespace WebApiMediator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        public IMediator Mediator { get; }
        public IMemoryCache Cache { get; }

        public PeopleController(IMediator mediator, IMemoryCache cache)
        {
            Mediator = mediator;
            Cache = cache;
        }
        [HttpGet]
        
        public async Task<IEnumerable<People>> Get(CancellationToken ct)
        {           
            //if (!Cache.TryGetValue<IEnumerable<People>>("CachePeopleList", out IEnumerable<People> peoples))
            //{
            //    peoples = 
            //    Cache.Set<IEnumerable<People>>("CachePeopleList",
            //        peoples,
            //        new MemoryCacheEntryOptions
            //        {
            //            AbsoluteExpiration = DateTime.Now.AddSeconds(30)
            //        });
            //}
            return await Mediator.FetchAsync(new QueryPeoples(), ct);
            
        }

        [HttpGet("{id}")]
        public async Task<People> Get(int id, CancellationToken ct)
        {
            return await Mediator.FetchAsync(new QueryPeopleById(id), ct);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] People value, CancellationToken ct)
        {
            return Ok(await Mediator.SendAsync(new CreatePeopleCommand { Name = value.Name }, ct));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] People value, CancellationToken ct)
        {
            if (value.Id != id) 
            { 
                return NotFound(); 
            }
            return Ok(
                await Mediator.SendAsync(new UpdatePeopleCommand
                {
                    PeopleId = value.Id,
                    Name = value.Name
                }, ct)
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            bool result = await Mediator.SendAsync(new DeletePeopleCommand { PeopleId = id }, ct);
            if (result)
            {
                return Ok(new { Status = true, Message = "People removed"  });
            }
            return NotFound();
        }
    }
}
