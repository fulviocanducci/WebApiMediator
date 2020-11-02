using SimpleSoft.Mediator;
using System.Collections.Generic;
using WebApiMediator.Models;

namespace WebApiMediator.Commands.Query
{
    public class QueryPeoples : Query<IEnumerable<People>>
    {
    }
}
