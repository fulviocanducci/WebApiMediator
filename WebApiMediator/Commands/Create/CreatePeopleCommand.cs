using SimpleSoft.Mediator;
using WebApiMediator.Models;

namespace WebApiMediator.Commands.Create
{
    public class CreatePeopleCommand : Command<People>
    {
        public string Name { get; set; }
    }
}
