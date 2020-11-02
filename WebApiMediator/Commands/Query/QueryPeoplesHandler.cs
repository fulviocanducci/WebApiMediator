using Microsoft.EntityFrameworkCore;
using SimpleSoft.Mediator;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApiMediator.Models;

namespace WebApiMediator.Commands.Query
{
    public class QueryPeoplesHandler : IQueryHandler<QueryPeoples, IEnumerable<People>>
    {
        public BasemediatorContext Context { get; }
        public QueryPeoplesHandler(BasemediatorContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<People>> HandleAsync(QueryPeoples query, CancellationToken ct)
        {
            return await Context.People
               .AsNoTracking()
               .ToListAsync();
        }
    }
}
