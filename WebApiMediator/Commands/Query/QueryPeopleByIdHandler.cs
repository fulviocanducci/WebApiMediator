using Microsoft.EntityFrameworkCore;
using SimpleSoft.Mediator;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiMediator.Models;

namespace WebApiMediator.Commands.Query
{
    public class QueryPeopleByIdHandler : IQueryHandler<QueryPeopleById, People>
    {
        public BasemediatorContext Context { get; }
        public QueryPeopleByIdHandler(BasemediatorContext context)
        {
            Context = context;
        }

        public async Task<People> HandleAsync(QueryPeopleById query, CancellationToken ct)
        {
            return await Context.People.AsNoTracking()
                    .Where(c => c.Id == query.PeopleId)
                    .FirstOrDefaultAsync();
        }
    }
}
