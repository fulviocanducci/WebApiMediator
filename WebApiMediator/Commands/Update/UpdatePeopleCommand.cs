using SimpleSoft.Mediator;
using System.Threading;
using System.Threading.Tasks;
using WebApiMediator.Models;
using Microsoft.EntityFrameworkCore;
namespace WebApiMediator.Commands.Update
{
    public class UpdatePeopleCommand : Command<People>
    {
        public int PeopleId { get; set; }
        public string Name { get; set; }
    }

    public class UpdatePeopleCommandHandler : ICommandHandler<UpdatePeopleCommand, People>
    {
        public BasemediatorContext Context { get; }

        public UpdatePeopleCommandHandler(BasemediatorContext context)
        {
            Context = context;
        }

        public async Task<People> HandleAsync(UpdatePeopleCommand cmd, CancellationToken ct)
        {
            People people = new People
            {
                Id = cmd.PeopleId,
                Name = cmd.Name
            };
            Context.Entry(people).State = EntityState.Modified;
            Context.Update(people);
            await Context.SaveChangesAsync();
            return people;
        }
    }
}
