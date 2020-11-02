using SimpleSoft.Mediator;
using System.Threading;
using System.Threading.Tasks;
using WebApiMediator.Models;

namespace WebApiMediator.Commands.Delete
{
    public class DeletePeopleCommandHandler : ICommandHandler<DeletePeopleCommand, bool>
    {
        public BasemediatorContext Context { get; }
        public DeletePeopleCommandHandler(BasemediatorContext context)
        {
            Context = context;
        }

        public async Task<bool> HandleAsync(DeletePeopleCommand cmd, CancellationToken ct)
        {
            People people = Context.People.Find(cmd.PeopleId);
            if (people != null)
            {
                Context.People.Remove(people);
                return await Context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
