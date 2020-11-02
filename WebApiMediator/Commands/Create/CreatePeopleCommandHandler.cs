using SimpleSoft.Mediator;
using System.Threading;
using System.Threading.Tasks;
using WebApiMediator.Models;

namespace WebApiMediator.Commands.Create
{
    public class CreatePeopleCommandHandler : ICommandHandler<CreatePeopleCommand, People>
    {
        public BasemediatorContext Context { get; }
        public CreatePeopleCommandHandler(BasemediatorContext context)
        {
            Context = context;
        }

        public async Task<People> HandleAsync(CreatePeopleCommand command, CancellationToken ct)
        {
            People people = new People
            {
                Name = command.Name
            };
            Context.People.Add(people);
            await Context.SaveChangesAsync();
            return people;
        }
    }
}
