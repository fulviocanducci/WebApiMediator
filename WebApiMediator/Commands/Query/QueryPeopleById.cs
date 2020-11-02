using SimpleSoft.Mediator;
using WebApiMediator.Models;

namespace WebApiMediator.Commands.Query
{
    public class QueryPeopleById : Query<People>
    {
        public QueryPeopleById()
        {
        }

        public QueryPeopleById(int peopleId)
        {
            PeopleId = peopleId;
        }
        public int PeopleId { get; set; }
    }
}
